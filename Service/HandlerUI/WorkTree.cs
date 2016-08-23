using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DbRepository.Classes.Context;
using DbRepository.Classes.Repository;
using DbRepository.Context;
using Microsoft.CSharp.RuntimeBinder;
using Service.Services;
using System.Drawing;
using Authentication;

namespace Service.HandlerUI
{
    public class WorkTree
    {
        // Список тем
        private List<Thema> _themaList;
        // Список подтем
        private List<SubThema> _subthemaList;
        // Список задач
        private List<Task> _taskList;
        // Текущее дерево
        private readonly TreeView _tree;
        // Сервис по работе с темами
        private readonly ThemaService _themaService;
        // Сервис по подтемам
        private readonly SubthemaService _subthemaService;
        // Сервис по работе с задачами
        private readonly TaskService _taskService;
        // Узел для копирования
        private TreeNode _sourceNode { get; set; }
        // Буфер выбранного узла
        public TreeNode SelectedNode { get; set; }

        /// <summary>
        /// Конструктор. Заполняет из БД дерево темами, подтемами, задачами
        /// </summary>
        /// <param name="tree">Дерево текущее</param>
        public WorkTree(TreeView tree)
        {
            _tree = tree;
            _themaService = new ThemaService();
            _subthemaService = new SubthemaService();
            _taskService = new TaskService();
        }

        /// <summary>
        /// Возвращает название типа форма необходимой для создания
        /// </summary>
        /// <returns>Название типа формы</returns>
        public string GetTypeFormNeedToCreateBySelectedNodeForEdit()
        {
            var currNode = SelectedNode;
            var parent = _tree.SelectedNode?.Parent;
            if (parent == null || parent.Parent == null)
            {
                return "FormEnterNew";
            }
            return "FormCreateTask";
        }

        /// <summary>
        /// Возвращает название типа форма необходимой для создания
        /// </summary>
        /// <returns>Название типа формы</returns>
        public string GetTypeFormNeedToCreateBySelectedNodeForCreate()
        {
            var currNode = SelectedNode;
            var parent = _tree.SelectedNode?.Parent;
            if (currNode == null || parent == null)
            {
                return "FormEnterNew";
            }
            return "FormCreateTask";
        }

        /// <summary>
        /// Метод, возвращающий ссылку на метод по добавлению нужного объекта (тема/подтема)
        /// </summary>
        /// <returns>Метод по добавлению из сервиса</returns>
        public Action<string, string, int[]> GetMethodForCreateNeededObject(out int[] id)
        {
            var currNode = SelectedNode;
            id = new int[2];
            if (currNode == null)
            {
                id[0] = 0;
                return _themaService.Add;
            }
            id[0] = GetThemaByNode(currNode).ThemaId;
            return _subthemaService.Add;
        }

        /// <summary>
        /// Метод возвращает ссылку на метод по редактированию темы/подтемы
        /// </summary>
        /// <param name="item">Тема/подтема для обновления</param>
        /// <param name="id">ИД нужного обекта [0] - тема ИД, [1] - подтема ИД</param>
        /// <returns>Метод обновления из сервиса</returns>
        public Action<string, string, int[]> GetMethodForUpdateNeededObject(dynamic item, out int[] id)
        {
            id = new int[2];
            try
            {
                if (item is Thema)
                {
                    id[0] = item.ThemaId;
                    return _themaService.Update;
                }
                if (item is SubThema)
                {
                    id[0] = item.ThemaId;
                    id[1] = item.SubthemaId;
                    return _subthemaService.Update;
                }
            }
            catch (RuntimeBinderException)
            {
                MessageBox.Show("GetMethodForUpdateNeededObject");
            }
            return null;
        }

        /// <summary>
        /// Метод возвращает ссылку на метод для удаления темы/подтемы
        /// </summary>
        /// <param name="id">ИД темы/подтемы</param>
        /// <returns>метод удаления темы или подтемы</returns>
        public Action<int> GetMethodForDeleteNeededObject(out int id)
        {
            var currNode = SelectedNode;
            var parent = _tree.SelectedNode?.Parent;
            if (parent == null)
            {
                var thema = GetThemaByNode(currNode);
                id = thema.ThemaId;
                return _themaService.Delete;
            }
            if (parent.Parent != null)
            {
                var task = GetTaskByNode(currNode);
                id = task.TaskId;
                return _taskService.Delete;
            }
            var subthema = GetSubthemaByNode(currNode);
            id = subthema.SubthemaId;
            return _subthemaService.Delete;
        }

        /// <summary>
        /// Создание задачи первоначальное
        /// </summary>
        /// <param name="name">Имя задачи</param>
        /// <param name="desc">Описание задачи</param>
        /// <param name="image">Графическое условие задачи (если есть)</param>
        public void CreateTask(Task task)
        {
            var subthemaId = GetSubthemaByNode(_tree.SelectedNode).SubthemaId;
            _taskService.Add(task.Name, task.Description, task.Image, subthemaId);
        }

        /// <summary>
        /// Получить задачу по имени и описанию
        /// </summary>
        /// <param name="name">Имя задачи</param>
        /// <param name="desc">Описание задачи</param>
        /// <returns>Объект задачи</returns>
        public Task GetTaskByNameAndDesc(string name, string desc)
        {
            return _taskList.Where(c => c.Name.Equals(name)).FirstOrDefault(c => c.Description.Equals(desc));
        }

        /// <summary>
        /// Получение из БД тем и подтем, заполнение ими дерева
        /// </summary>
        public void FillTree()
        {
            GetAllObjectsFormDb();
            MoveObjectsFromListToTree();
        }

        /// <summary>
        /// Обновления узлов дерева
        /// </summary>
        public void UpdateTree()
        {
            _tree.Nodes.Clear();
            FillTree();
            _tree.ExpandAll();
        }

        /// <summary>
        /// Возвращает объект (тема/подтема) по выбранному узлу в дереве
        /// </summary>
        /// <returns></returns>
        public dynamic GetObjectBySelectedNode()
        {
            var currNode = SelectedNode;
            var parent = _tree.SelectedNode?.Parent;
            if (parent == null)
                return GetThemaByNode(currNode);
            if (parent != null && parent.Parent == null)
                return GetSubthemaByNode(currNode);
            return GetTaskByNode(currNode);
        }

        /// <summary>
        /// Вернуть тип для создаваемой формы (по узлу определяется кака форма должна быть создана)
        /// </summary>
        /// <returns>Тип создаваемой формы</returns>
        public Type GetTypeForCreatingFormForEdit()
        {
            var typeString = GetTypeFormNeedToCreateBySelectedNodeForEdit();
            return Type.GetType($"DistanceStudy.Forms.Teacher.{typeString}, DistanceStudy");
        }

        /// <summary>
        /// Вернуть тип для создаваемой формы (по узлу определяется кака форма должна быть создана)
        /// </summary>
        /// <returns>Тип создаваемой формы</returns>
        public Type GetTypeForCreatingFormForCreate()
        {
            var typeString = GetTypeFormNeedToCreateBySelectedNodeForCreate();
            return Type.GetType($"DistanceStudy.Forms.Teacher.{typeString}, DistanceStudy");
        }

        /// <summary>
        /// Инициализация узла для копирования
        /// </summary>
        /// <param name="node">Копируемы узел</param>
        public void SetNodeToCopy(TreeNode node)
        {
            _sourceNode = node;
        }

        /// <summary>
        /// Вставить скопированный узел
        /// </summary>
        public void PastCopiedNode()
        {
            if (_sourceNode == null) return;
            var thema = GetThemaByNode(_sourceNode);
            if (thema != null)
            {
                _themaService.Add(thema.Name, thema.Description, 0);
                return;
            }
            var subthema = GetSubthemaByNode(_sourceNode);
            if (thema != null)
            {
                _subthemaService.Add(thema.Name, thema.Description, 0);
                return;
            }
        }

        /// <summary>
        /// Обновить или добавить задачу в соответствии с параметрами
        /// </summary>
        /// <param name="workerTask">Обработчик задач</param>
        /// <param name="method">Метод, выполняемый над задачей</param>
        /// <param name="name">Название задачи</param>
        /// <param name="desc">Описание задачи</param>
        /// <param name="image">Картинка</param>
        public void DoOperationWithTaskByCall(ref WorkTask workerTask, Action<Task> method, string name, string desc, Bitmap image)
        {
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            image?.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
            method(new Task
            {
                Name = name,
                Description = desc,
                Image = stream.ToArray()
            });
            UpdateTree();
            var createdTask = GetTaskByNameAndDesc(name, desc);
            if (workerTask == null)
            {
                workerTask = new WorkTask(createdTask);
            }
        }

        /// <summary>
        /// Получение всех тем в список из БД
        /// </summary>
        private void GetAllObjectsFormDb()
        {
            _themaList?.Clear();
            _subthemaList?.Clear();
            _taskList?.Clear();
            var dbThema = new ThemaRepository();
            _themaList = dbThema.GetAll();
            var dbSubthema = new SubthemaRepository();
            _subthemaList = dbSubthema.GetAll();
            var dbTask = new TaskRepository();
            _taskList = dbTask.GetAll();
        }

        /// <summary>
        /// Перемещение объектов из списков в дерево
        /// </summary>
        private void MoveObjectsFromListToTree()
        {
            foreach (var item in _themaList)
            {
                _tree.Nodes.Add(item.Name);
                AddSubthemasFromThemaToTree(item);
            }
        }

        /// <summary>
        /// Добавить подтемы в узел темы
        /// </summary>
        /// <param name="item">Тема, в которую нужно добавить подтемы</param>
        private void AddSubthemasFromThemaToTree(Thema item)
        {
            var subthemasOfThema = _subthemaList.Where(c => c.ThemaId.Equals(item.ThemaId));
            foreach (var subthema in subthemasOfThema)
            {
                var index = _tree.Nodes.Count - 1;
                _tree.Nodes[index].Nodes.Add(subthema.Name);
                AddTasksFromSubthemaToTree(subthema, _tree.Nodes[index].Nodes);
            }
        }

        /// <summary>
        /// Добавление задач под подтему
        /// </summary>
        /// <param name="item">Подтема, в которую добавляются задачи</param>
        private void AddTasksFromSubthemaToTree(SubThema item, TreeNodeCollection targetNodes)
        {
            var tasks = _taskList.Where(c => c.SubthemaId.Equals(item.SubthemaId));
            foreach (var task in tasks)
            {
                bool isTeacher = false;
                var userSettings = AuthenticationModule.LoggedUser?.Permission?.IsTeacher;
                if (userSettings.HasValue)
                    isTeacher = userSettings.Value;
                var index = targetNodes.Count - 1;
                if (isTeacher || task.IsReady)
                {
                    targetNodes[index].Nodes.Add(task.Name);
                    SetColorForTaskNode(task, targetNodes[index].LastNode);
                }  
            }
        }

        /// <summary>
        /// Установить цвет узла в зависимости от готовности задачи
        /// </summary>
        /// <param name="task">Задача</param>
        /// <param name="node">Узел задачи</param>
        private void SetColorForTaskNode(Task task, TreeNode node)
        {
            node.ForeColor = (task.IsReady) ? Color.Green : Color.Red;
        }

        /// <summary>
        /// Вернуть тему по узлу из списка в дереве TreeView
        /// </summary>
        /// <param name="currNode">Узел дерева</param>
        /// <returns>Тема</returns>
        private Thema GetThemaByNode(TreeNode currNode)
        {
            return _themaList.FirstOrDefault(c => c.Name.Equals(currNode.Text));
        }

        /// <summary>
        /// Вернуть подтему по узлу из списка
        /// </summary>
        /// <param name="currNode">Узел дерева</param>
        /// <returns>Подтема</returns>
        private SubThema GetSubthemaByNode(TreeNode currNode)
        {
            return _subthemaList.FirstOrDefault(c => c.Name.Equals(currNode.Text));
        }

        /// <summary>
        /// Вернуть задачу по узлу в дереве
        /// </summary>
        /// <param name="currNode">Узел дерева</param>
        /// <returns>Задача</returns>
        private Task GetTaskByNode(TreeNode currNode)
        {
            return _taskList.FirstOrDefault(c => c.Name.Equals(currNode.Text));
        }
    }
}
