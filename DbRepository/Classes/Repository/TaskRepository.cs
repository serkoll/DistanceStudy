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

        /// <summary>
        /// Удаление задачи по ИД
        /// </summary>
        /// <param name="id">ИД удаляемой задачи</param>
        public void Delete(int id)
        {
            using (var db = new DistanceStudyEntities())
            {
                var deleted = db.Tasks.Find(id);
                if (deleted != null)
                {
                    DeleteAlgorithmsFromTask(deleted);
                    db.Tasks.Remove(deleted);
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Добавление алгоритма для опредленной задачи
        /// </summary>
        /// <param name="taskId">Задача, которая проверяется алгоритмом</param>
        /// <param name="condition">Методы проверки в алгоритме</param>
        public void AddAlgorithm(int taskId, string condition)
        {
            using (var db = new DistanceStudyEntities())
            {
                db.Task_Algotithm.Add(new DbRepository.Context.Task_Algotithm
                {
                    TaskId = taskId,
                    Condition = condition,
                    SubGroup = 1,
                    BlockNumber = 1
                });
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Вернуть по объекту задачи набор методов проверки
        /// </summary>
        /// <param name="task">Объект задачи</param>
        /// <returns>Объект алгоритма проверки</returns>
        public Task_Algotithm GetTaskAlgorithmForTask(Task task)
        {
            using (var db = new DistanceStudyEntities())
            {
                var getted = db.Task_Algotithm.Where(c => c.TaskId.Equals(task.TaskId));
                return getted?.FirstOrDefault();
            }
        }

        /// <summary>
        /// Обновление задачи
        /// </summary>
        /// <param name="task">Объект задачи с новыми параметрами</param>
        public void Update(Task task)
        {
            using (var db = new DistanceStudyEntities())
            {
                var updated = db.Tasks.Find(task.TaskId);
                if (updated != null)
                {
                    updated.Image = task.Image;
                    updated.IsReady = task.IsReady;
                    updated.Name = task.Name;
                    updated.SubthemaId = task.SubthemaId;
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Удаление всех агоритмов из текущей задачи
        /// </summary>
        /// <param name="task">Задача, из которой удаляются все алгоритмы</param>
        private void DeleteAlgorithmsFromTask(Task task)
        {
            using (var db = new DistanceStudyEntities())
            {
                foreach (var item in db.Task_Algotithm.Where(c => c.TaskId.Equals(task.TaskId)))
                {
                    db.Task_Algotithm.Remove(item);
                }
                db.SaveChanges();
            }
        }
    }
}
