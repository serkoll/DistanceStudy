using DbRepository.Classes.Repository;
using DbRepository.Context;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Service.Services
{
    public class TaskService
    {
        // Репозиторий для добавление в БД тем
        private readonly TaskRepository _taskRep = new TaskRepository();

        /// <summary>
        /// Первоначальное добавление задачи без параметров в бд
        /// </summary>
        /// <param name="name">Имя задачи</param>
        /// <param name="desc">Описание задачи</param>
        /// <param name="bmp">Графическое условие (если есть)</param>
        /// <param name="subthemaId">К какой подтеме относится задача</param>
        public void Add(string name, string desc, Bitmap bmp, int subthemaId)
        {
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            bmp?.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
            _taskRep.Add(new Task
            {
                Name = name,
                Description = desc,
                Image = stream?.ToArray(),
                SubthemaId = subthemaId 
            });
        }

        /// <summary>
        /// Удаление задачи по ИД из БД
        /// </summary>
        /// <param name="id">ИД задачи</param>
        public void Delete(int id)
        {
            _taskRep.Delete(id);
        }

        /// <summary>
        /// Добавить алгоритм для текущей задачи
        /// </summary>
        /// <param name="id">ИД задачи</param>
        /// <param name="condition">Метод или перечень методов в алгоритме проверки</param>
        public void AddAlgorithm(int id, string condition)
        {
            _taskRep.AddAlgorithm(id, condition);
        }

        /// <summary>
        /// Обновить задачу
        /// </summary>
        /// <param name="task">Задача с новыми параметрами</param>
        public void UpdTask(Task task)
        {
            _taskRep.Update(task);
        }
    }
}
