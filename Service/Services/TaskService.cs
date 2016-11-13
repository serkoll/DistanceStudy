using DbRepository.Classes.Repository;
using DbRepository.Context;
using System;
using System.Linq;
using System.Reflection;

namespace Service.Services
{
    public class TaskService
    {
        // Репозиторий для добавление в БД тем
        protected readonly TaskRepository _taskRep = new TaskRepository();

        /// <summary>
        /// Первоначальное добавление задачи без параметров в бд
        /// </summary>
        /// <param name="name">Имя задачи</param>
        /// <param name="desc">Описание задачи</param>
        /// <param name="bmp">Графическое условие (если есть)</param>
        /// <param name="subthemaId">К какой подтеме относится задача</param>
        public void Add(string name, string desc, byte[] bmp, int subthemaId)
        {
            _taskRep.Add(new Task
            {
                Name = name,
                Description = desc,
                Image = bmp,
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

        /// <summary>
        /// Получение всех методов проверки из заданной сборки
        /// </summary>
        /// <param name="assembly">Название класса в сборке Point3DCntrl</param>
        public MethodInfo[] GetAllMethodsFromAssembly(string assembly = "PointsProectionsControl")
        {
            Type type = Type.GetType($"Point3DCntrl.{assembly}, Point3DCntrl");
            var pointsPrtcCntrl = Activator.CreateInstance(type);
            Type t = pointsPrtcCntrl.GetType();
            return t.GetMethods();
        }

        /// <summary>
        /// Добавление ссылок на методы
        /// </summary>
        /// <param name="taskId">ИД задачи</param>
        /// <param name="targetMethod">Метод для которого нужен параметр</param>
        /// <param name="sourceMethod">Метод из которого он берется</param>
        /// <param name="param">Параметр (тип)</param>
        public void AddReferenceMethods(int taskId, string targetMethod, string sourceMethod, string param)
        {
            _taskRep.AddReferenceMethods(taskId, new Task_MethodRef
            {
                TargetMethod = targetMethod,
                SourceMethod = sourceMethod,
                Param = param,
                IdTask = taskId
            });
        }

        /// <summary>
        /// Получение по задаче и методу из которого нужно брать результат - метод, в который результат нужно поместить
        /// </summary>
        /// <param name="task">Задача</param>
        /// <param name="methodSource">Метод, который дает результат</param>
        /// <returns>Название метода, в который этот результат помещается</returns>
        public string GetRefMethodNameForKey(Task task, string methodSource)
        {
            var taskMethodRef = _taskRep.GetTaskMethodRefByTaskId(task).FirstOrDefault(c => c.SourceMethod.Equals(methodSource));
            if (taskMethodRef != null)
                return taskMethodRef.TargetMethod;
            return string.Empty;
        }
    }
}
