using DbRepository.Context;
using Service.Services;
using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using XMLFormatter;

namespace Service.HandlerUI
{
    /// <summary>
    /// Класс для работы с задачей
    /// </summary>
    public class WorkTask
    {
        // Сервис работы с задачами
        private TaskService _taskService;
        // Активная задача
        private Task _task;
        // Методы проверки задач
        private MethodInfo[] mi;
        public WorkTask(Task task)
        {
            _taskService = new TaskService();
            _task = task;
            GetAllMethodsFromAssembly();
        }

        /// <summary>
        /// Заполнить листбокс названиями методов из сборки с методами контроля (Point3DCntrl)
        /// </summary>
        public void FillListBoxByCntrlAssembly(CheckedListBox checkedListBoxProectionsControls)
        {
            foreach (MethodInfo m in mi)
            {
                if (m.DeclaringType.Name.Equals("PointsProectionsControl"))
                    checkedListBoxProectionsControls.Items.Add(m.Name);
            }
        }

        /// <summary>
        /// Добавить алгоритм для текущей задачи
        /// </summary>
        /// <param name="checkedListBoxProectionsControls">Список методов проверки для задачи</param>
        public void AddAlgothm(CheckedListBox checkedListBoxProectionsControls)
        {
            var formattedStr = XmlFormatter.WriteAlgorithm2XmlFromCheckListBox(checkedListBoxProectionsControls.CheckedItems);
            _taskService.AddAlgorithm(_task.TaskId, formattedStr);
        }

        /// <summary>
        /// Обновления статуса задачи
        /// </summary>
        public void SetTaskStatusToReady()
        {
            _task.IsReady = true;
            _taskService.UpdTask(_task);
        }

        /// <summary>
        /// Обновить текущую задачу
        /// </summary>
        public void UpdateCurrentTask(Task updTask)
        {
            _task.Name = updTask.Name;
            _task.Image = updTask.Image;
            _task.Description = updTask.Description;
            _taskService.UpdTask(_task);
        }

        /// <summary>
        /// Получение всех методов проверки из заданной сборки
        /// </summary>
        /// <param name="assemly">Название класса в сборке Point3DCntrl</param>
        private void GetAllMethodsFromAssembly(string assemly = "PointsProectionsControl")
        {
            Type type = Type.GetType($"Point3DCntrl.{assemly}, Point3DCntrl");
            var pointsPrtcCntrl = Activator.CreateInstance(type);
            Type t = pointsPrtcCntrl.GetType();
            mi = t.GetMethods();
        }
    }
}
