﻿using System.Collections.Generic;
using System.Linq;
using DbRepository.Context;
using System.Data.Entity;

namespace DbRepository.Classes.Repository
{
    /// <summary>
    /// Класс, отвечающий за темы в БД
    /// </summary>
    public class ThemaRepository
    {
        /// <summary>
        /// Добавление темы в бд
        /// </summary>
        /// <param name="thema">Добавляемая тема</param>
        public void Add(Thema thema)
        {
            using (var db = new DistanceStudyEntities())
            {
                db.Themas.Add(thema);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Получение всех тем из бд
        /// </summary>
        /// <returns>Список всех тем</returns>
        public List<Thema> GetAll()
        {
            using (var db = new DistanceStudyEntities())
            {
                return db.Set<Thema>().ToList();
            }
        }

        /// <summary>
        /// Обновление темы
        /// </summary>
        /// <param name="thema">Обновляемая тема</param>
        public void Update(Thema thema)
        {
            using (var db = new DistanceStudyEntities())
            {
                var updated = db.Themas.Find(thema.ThemaId);
                if (updated != null)
                {
                    updated.SubThemas = thema.SubThemas;
                    updated.Name = thema.Name;
                    updated.Description = updated.Description;
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Удаление темы
        /// </summary>
        /// <param name="id">Ид удаляемой темы</param>
        public void Delete(int id)
        {
            using (var db = new DistanceStudyEntities())
            {
                var deleted = db.Themas.Find(id);
                if (deleted != null)
                {
                    DeleteSubthemasFromThemaById(db.SubThemas, id);
                    db.Themas.Remove(deleted);
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Удаление всех подтем из темы
        /// </summary>
        /// <param name="dbSubthemas">Сет всех подтем</param>
        /// <param name="id">ИД темы</param>
        private void DeleteSubthemasFromThemaById(DbSet<SubThema> dbSubthemas, int id)
        {
            foreach (var item in dbSubthemas.Where(c => c.ThemaId.Equals(id)))
            {
                DeleteTasksFromSubthema(item);
                dbSubthemas.Remove(item);
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