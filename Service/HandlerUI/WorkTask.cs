using System.Reflection;
using System.Windows.Forms;
using DbRepository.Context;
using Service.Services;
using Formatter;

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
            mi = _taskService.GetAllMethodsFromAssembly();
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
        /// Заполнить комбобокс названием методов из сборки проверки методами контроля
        /// </summary>
        /// <param name="comboBox">Комбобокс с методами</param>
        public void FillComboBoxByCntrlAssembly(ComboBox comboBox)
        {
            foreach (MethodInfo m in mi)
            {
                if (m.DeclaringType.Name.Equals("PointsProectionsControl"))
                    comboBox.Items.Add(m.Name);
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
        /// Убрать выделение всех чекбоксов
        /// </summary>
        /// <param name="checkedListBox">Список чекбоксов</param>
        public void UncheckAllItems(CheckedListBox checkedListBox)
        {
            for (int i = 0; i < checkedListBox.Items.Count; i++)
                checkedListBox.SetItemCheckState(i, CheckState.Unchecked);
        }

        /// <summary>
        /// Изменения на форме описательной части выбранного алгоритма
        /// </summary>
        /// <param name="selectedMethodName">Выбранный метод</param>
        /// <param name="textBoxDesc">Описание алгоритма</param>
        /// <param name="listBoxUserParam">Листбокс с параметрами, которые требуются от пользователя</param>
        /// <param name="listBoxInitialParam">Листбокс с параметрами, которые требуется передать для инициализации алгоритма</param>
        public void ChangeInfoAboutSelectedItem(string selectedMethodName, TextBox textBoxDesc, ListBox listBoxUserParam, ListBox listBoxInitialParam, ListBox listBoxSolveParams)
        {
            textBoxDesc.Text = string.Empty;
            listBoxInitialParam.Items.Clear();
            listBoxUserParam.Items.Clear();
            listBoxSolveParams.Items.Clear();
            string desc = string.Empty;
            string[] userParams = new string[0],
                   initParams = new string[0],
                   solveParams = new string[0];
            XmlFormatter.GetInfoAboutMethodFromXml(selectedMethodName, out desc, out userParams, out initParams, out solveParams);
            textBoxDesc.Text = desc;
            AddParamsToListBox(listBoxInitialParam, initParams);
            AddParamsToListBox(listBoxUserParam, userParams);
            AddParamsToListBox(listBoxSolveParams, solveParams);
        }

        /// <summary>
        /// Проверка на наличие у данного метода выходных параметров
        /// </summary>
        /// <param name="method">Название метода</param>
        /// <param name="listBoxInitialParams">Лист его выходных параметров</param>
        /// <returns></returns>
        public bool CheckItemOnInitialParams(string method, ListBox listBoxInitialParams)
        {
            foreach (var item in listBoxInitialParams.Items)
            {
                if (item.ToString() != string.Empty)
                {
                    return true;
                }  
            }
            return false;
        }

        /// <summary>
        /// Добавление ссылки для выходных и входных параметров для методов проверки
        /// </summary>
        /// <param name="targetMethod">Метод в который необходимы данные</param>
        /// <param name="sourceMethod">Метод из решения которого они будут взяты</param>
        /// <param name="param">Тип взятого параметра</param>
        public void AddReferenceToinitialMethod(string targetMethod, string sourceMethod, string param)
        {
            _taskService.AddReferenceMethods(_task.TaskId, targetMethod, sourceMethod, param);
        }

        /// <summary>
        /// Добавление списка параметров в листбоксы
        /// </summary>
        /// <param name="listBox">Лист бокс</param>
        /// <param name="parameters">Список текстовых параметров</param>
        private void AddParamsToListBox(ListBox listBox, string[] parameters)
        {
            for (int i = 0; i < parameters.Length; i++)
            {
                listBox.Items.Add(parameters[i]);
            }
        }
    }
}
