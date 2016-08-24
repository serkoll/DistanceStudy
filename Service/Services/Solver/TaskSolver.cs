using DbRepository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Service.Services.Solver
{
    public class TaskSolver : TaskService
    {
        /// <summary>
        /// Проверка текущей задачи
        /// </summary>
        /// <param name="task">Задача для проверки</param>
        public void StartCheckTask(Task task)
        {
            Dictionary<string, object> InitialParams = new Dictionary<string, object>();
            Dictionary<string, object> UserParams = new Dictionary<string, object>();
            Dictionary<string, object> SolveParams = new Dictionary<string, object>();
            Dictionary<string, string> CommentsTrue = new Dictionary<string, string>();
            Dictionary<string, string> CommentsFalse = new Dictionary<string, string>();
            object classInstance = Activator.CreateInstance(Type.GetType($"Point3DCntrl.PointsProectionsControl, Point3DCntrl"), null);
            var listMethods = GetMethodsFromDbForTask(task);
            foreach (var c in listMethods)
            {
                c.Invoke(classInstance, new object[] { InitialParams, UserParams, SolveParams, CommentsTrue, CommentsFalse });
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
    }
}
