using DbRepository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GraphicsModule;
using GeometryObjects;
using System.Text;
using XMLFormatter;

namespace Service.Services.Solver
{
    public class TaskSolver : TaskService
    {
        private Dictionary<string, object> initialParams = new Dictionary<string, object>();
        private Dictionary<string, object> userParams = new Dictionary<string, object>();
        private Dictionary<string, object> solveParams = new Dictionary<string, object>();
        private Dictionary<string, string> commentsTrue = new Dictionary<string, string>();
        private Dictionary<string, string> commentsFalse = new Dictionary<string, string>();

        private Dictionary<string, object> queueParams = new Dictionary<string, object>();
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

            // Test feature -> TODO: Remove
            var graphicObjects = CollectionsGraphicsObjects.GraphicsObjectsCollection;
            string initParam = string.Empty,
                   userParam = string.Empty,
                   solveParam = string.Empty,
                   desc = string.Empty;
            object objInit = null,
                objSolve = null;
            foreach (var c in listMethods)
            {
                XmlFormatter.GetInfoAboutMethodFromXml(c.Name, ref desc, ref userParam, ref initParam, ref solveParam);
                if (userParam != string.Empty)
                {
                    userParams.Add(userParam, graphicObjects.FirstOrDefault());
                }
                if (initParam != string.Empty)
                {
                    solveParams.TryGetValue(c.Name, out objInit);
                    if (objInit != null)
                    {
                        initialParams.Add(initParam, objInit);
                    }  
                }
                c.Invoke(classInstance, new object[] { initialParams, userParams, solveParams, commentsTrue, commentsFalse });
                if (solveParam != string.Empty)
                {
                    var methodTarget = GetRefMethodNameForKey(task, c.Name);
                    solveParams.TryGetValue(solveParam, out objSolve);
                    solveParams.Remove(solveParam);
                    solveParams.Add(methodTarget, objSolve);
                }
                userParams.Clear();
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
                for (int i = 0; i < methNames.Count(); i++)
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
