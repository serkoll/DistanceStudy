using DbRepository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbRepository.Classes.Repository
{
    public class TaskRepository
    {
        /// <summary>
        /// Добавление задачи в бд
        /// </summary>
        /// <param name="task">Добавляемая задача</param>
        public void Add(Task task)
        {
            using (var db = new DistanceStudyEntities())
            {
                db.Tasks.Add(task);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Получение всех задач из бд
        /// </summary>
        /// <returns>Список задач</returns>
        public List<Task> GetAll()
        {
            using (var db = new DistanceStudyEntities())
            {
                return db.Set<Task>().ToList();
            }
        }
    }
}
