using DbRepository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GraphicsModule;
using System.Text;
using Point3DCntrl;
using Formatter;

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
        public string StartCheckTask(Task task)
        {
            ClearAllDictionaries();
            StringBuilder sb = new StringBuilder();
            var classInstance = Activator.CreateInstance(Type.GetType($"Point3DCntrl.PointsProectionsControl, Point3DCntrl"), null);
            var listMethods = GetMethodsFromDbForTask(task);
            #region Debug options

            var graphicObjects = CollectionsGraphicsObjects.GraphicsObjectsCollection;
            JsonFormatter.WriteObjectsToJson(graphicObjects);
            string[] initParam, userParam, solveParam;
            string desc;
            object objInit = null, objSolve = null;
            foreach (var c in listMethods)
            {
                XmlFormatter.GetInfoAboutMethodFromXml(c.Name, out desc, out userParam, out initParam, out solveParam);                
                if (initParam.Length > 0 && initParam[0] != string.Empty)
                {
                    // получаем список доступных ключей для текущей задачи
                    var keys = _taskRep.GetTaskMethodRefByTaskId(task);
                    foreach (var item in keys)
                    {
                        solveParams.TryGetValue(item, out objInit);
                        if (objInit != null)
                        {
                            initialParams.Add(item, objInit);
                        }
                    }
                }
                solveParams.Clear();
                if (userParam.Length > 0 && userParam[0] != string.Empty)
                {
                    for (int i = 0; i < graphicObjects.Count; i++)
                    {
                        for (int j = 0; j < userParam.Length; j++)
                        {
                            if (graphicObjects[i].GetType().Name.Equals(userParam[i]))
                            {
                                var keys = JsonFormatter.GetGraphicKeysFromJson().Where(k => k.TypeName.Equals(userParam[j]));
                                foreach (var key in keys)
                                {
                                    if (!userParams.ContainsKey(key))
                                    {
                                        userParams.Add(key, graphicObjects[i]);
                                        break;
                                    } 
                                }
                                graphicObjects.Remove(graphicObjects[i]);
                            } 
                        }
                    }
                }
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

            #endregion
            return sb.ToString();
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
