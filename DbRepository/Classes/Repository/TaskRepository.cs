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
