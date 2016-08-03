using System.Collections.Generic;
using DbRepository.Context;
using System.Linq;

namespace DbRepository.Classes.Context
{
    public class SubthemaRepository
    {
        /// <summary>
        /// Добавление подтемы в бд
        /// </summary>
        /// <param name="item">Объект подтемы</param>
        public void AddSubthema(SubThema item)
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
        public List<SubThema> GetAllSubthemas()
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
        public void UpdateSubthema(SubThema item)
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
        public void DeleteSubthema(int id)
        {
            using (var db = new DistanceStudyEntities())
            {
                var deleted = db.SubThemas.Find(id);
                if (deleted != null)
                {
                    db.SubThemas.Remove(deleted);
                    db.SaveChanges();
                }
            }
        }

        public SubThema GetSubthema(string name)
        {
            return null;
        }
    }
}