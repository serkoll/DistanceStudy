using DbRepository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GraphicsModule;
using GeometryObjects;
using System.Text;

namespace Service.Services.Solver
{
    public class TaskSolver : TaskService
    {
        private Dictionary<string, object> initialParams = new Dictionary<string, object>();
        private Dictionary<string, object> userParams = new Dictionary<string, object>();
        private Dictionary<string, object> solveParams = new Dictionary<string, object>();
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

            // Test feature -> TODO: Remove
            var point = CollectionsGraphicsObjects.GraphicsObjectsCollection.FirstOrDefault();
            userParams.Add(nameof(Point3D), point);
            foreach (var c in listMethods)
            {
                c.Invoke(classInstance, new object[] { initialParams, userParams, solveParams, commentsTrue, commentsFalse });
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
