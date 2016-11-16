using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using DbRepository.Classes.Keys;
using DbRepository.Context;
using Formatter;
using GraphicsModule.Geometry.Objects;

namespace Service.Services.Solver
{
    public class TaskSolver : TaskService
    {
        private Dictionary<Task_MethodRef, object> initialParams = new Dictionary<Task_MethodRef, object>();
        private Dictionary<GraphicKey, object> userParams = new Dictionary<GraphicKey, object>();
        private Dictionary<Task_MethodRef, object> solveParams = new Dictionary<Task_MethodRef, object>();
        private Dictionary<string, string> commentsTrue = new Dictionary<string, string>();
        private Dictionary<string, string> commentsFalse = new Dictionary<string, string>();

        /// <summary>
        /// Проверка текущей задачи
        /// </summary>
        /// <param name="task">Задача для проверки</param>
        public string StartCheckTask(Task task, Collection<IObject> graphicObjects)
        {
            ClearAllDictionaries();
            var sb = new StringBuilder();
            var classInstance = Activator.CreateInstance(Type.GetType($"Point3DCntrl.PointsProectionsControl, Point3DCntrl"), null);
            var listMethods = GetMethodsFromDbForTask(task);

            JsonFormatter.WriteObjectsToJson(graphicObjects);
            foreach (var c in listMethods)
            {
                string desc;
                string[] initParam;
                string[] solveParam;
                string[] userParam;
                XmlFormatter.GetInfoAboutMethodFromXml(c.Name, out desc, out userParam, out initParam, out solveParam);                
                ResolveKeyDependencyFromSolveToInit(task, initParam);
                ResolveKeyDependencyUserParam(userParam, graphicObjects);
                c.Invoke(classInstance, new object[] { task, initialParams, userParams, solveParams, commentsTrue, commentsFalse });
                initialParams.Clear();
            }
            if (commentsFalse.Any())
            {
                sb.Append("Неверно: \n");
                foreach (var comm in commentsFalse)
                {
                    sb.Append(comm).Append("\n");
                }
                sb.Append("Задача решена неправильно!");
            }
            else
            {
                sb.Append("Верно: \n");
                foreach (var comm in commentsTrue)
                {
                    sb.Append(comm).Append("\n");
                }
                sb.Append("Поздравляем! Задача решена верно!");
            }
            return sb.ToString();
        }

        /// <summary>
        /// Метод извлекает объекты из коллекции графических объектов
        /// и ставит в соответствие ключ для извлечения в проверке
        /// </summary>
        /// <param name="userParam">Параметры введенные студентом</param>
        /// <param name="graphicObjects">Графические объекты</param>
        private void ResolveKeyDependencyUserParam(string[] userParam, IList<IObject> graphicObjects)
        {
            // проверка на необходимость параметров от студента
            if (userParam.Length > 0 && userParam[0] != string.Empty)
            {
                for (int i = 0; i < graphicObjects.Count; i++)
                {
                    for (int j = 0; j < userParam.Length; j++)
                    {
                        // проверка на соответствие типа графического объекта типу необходимому от пользователя
                        if (graphicObjects[i].GetType().Name.Equals(userParam[i]))
                        {
                            // получение ключа для данного типа объекта
                            var keys = JsonFormatter.GetGraphicKeysFromJson().Where(k => k.TypeName.Equals(userParam[j]));
                            foreach (var key in keys)
                            {
                                // если в словаре нет объекта, то добавить
                                if (!userParams.ContainsKey(key))
                                {
                                    userParams.Add(key, graphicObjects[i]);
                                    break;
                                }
                            }
                            // очищаем объект, который добавили в словарь
                            graphicObjects.Remove(graphicObjects[i]);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Метод получает доступные ключи для задачи и перемещает значения по ключу
        /// из списка с объектами solve в список init для другого метода
        /// </summary>
        /// <param name="task">Текущая задача</param>
        /// <param name="initParam">Параметры инициализации для метода</param>
        private void ResolveKeyDependencyFromSolveToInit(Task task, IReadOnlyList<string> initParam)
        {
            // проверка на существование параметров инициализации
            if (initParam.Count > 0 && initParam[0] != string.Empty)
            {
                // получаем список доступных ключей для текущей задачи
                var keys = _taskRep.GetTaskMethodRefByTaskId(task);
                foreach (var item in keys)
                {
                    object objInit;
                    // забрать из решений объект по ключу нужный текущему методу
                    solveParams.TryGetValue(item, out objInit);
                    if (objInit != null)
                    {
                        initialParams.Add(item, objInit);
                    }
                }
            }
        }

        /// <summary>
        /// Поиск методов проверки для текущей задачи
        /// </summary>
        /// <param name="task">Задача для проверки</param>
        /// <returns>Методы проверки</returns>
        public List<MethodInfo> GetMethodsFromDbForTask(Task task)
        {
            List<MethodInfo> miList = new List<MethodInfo>();
            MethodInfo[] mi = GetAllMethodsFromAssembly();
            var algorithm = _taskRep.GetTaskAlgorithmForTask(task);
            string[] methNames = algorithm?.Condition.Split(';');
            foreach (var item in mi)
            {
                for (int i = 0; i < methNames?.Count(); i++)
                {
                    if (item.Name.Equals(methNames[i]))
                    {
                        miList.Add(item);
                        break;
                    }
                }
            }
            return miList;
        }

        /// <summary>
        /// Очистить все словари
        /// </summary>
        private void ClearAllDictionaries()
        {
            initialParams.Clear();
            userParams.Clear();
            solveParams.Clear();
            commentsFalse.Clear();
            commentsTrue.Clear();
        }
    }
}
