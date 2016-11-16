using System.Collections.Generic;
using System.Linq;
using DbRepository.Context;

namespace DbRepository.Classes.Repository
{
    public class SubthemaRepository
    {
        /// <summary>
        /// Добавление подтемы в бд
        /// </summary>
        /// <param name="item">Объект подтемы</param>
        public void Add(SubThema item)
        {
            using (var db = new DistanceStudyEntities())
            {
                db.SubThemas.Add(item);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Получение всех подтем из бд
        /// </summary>
        /// <returns>Список всех тем</returns>
        public List<SubThema> GetAll()
        {
            using (var db = new DistanceStudyEntities())
            {
                return db.Set<SubThema>().ToList();
            }
        }

        /// <summary>
        /// Обновление подтемы
        /// </summary>
        /// <param name="item">Обновляемая подтема</param>
        public void Update(SubThema item)
        {
            using (var db = new DistanceStudyEntities())
            {
                var updated = db.SubThemas.Find(item.SubthemaId);
                if (updated != null)
                {
                    updated.ThemaId = item.ThemaId;
                    updated.Name = item.Name;
                    updated.Description = updated.Description;
                    updated.Tasks = item.Tasks;
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Удаление подтемы
        /// </summary>
        /// <param name="id">Ид удаляемой подтемы</param>
        public void Delete(int id)
        {
            using (var db = new DistanceStudyEntities())
            {
                var deleted = db.SubThemas.Find(id);
                if (deleted != null)
                {
                    DeleteTasksFromSubthema(deleted);
                    db.SubThemas.Remove(deleted);
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Удаление всех заданий из подтемы
        /// </summary>
        /// <param name="subthema">Подтема</param>
        private void DeleteTasksFromSubthema(SubThema subthema)
        {
            using (var db = new DistanceStudyEntities())
            {
                foreach (var item in db.Tasks.Where(c => c.SubthemaId.Equals(subthema.SubthemaId)))
                {
                    DeleteAlgorithmsFromTask(item);
                    db.Tasks.Remove(item);
                }
                db.SaveChanges();
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