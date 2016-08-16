using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DbRepository.Classes.Context;
using DbRepository.Classes.Repository;
using DbRepository.Context;
using Microsoft.CSharp.RuntimeBinder;
using Service.Services;

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

        /// <summary>
        /// Конструктор. Заполняет из БД дерево темами, подтемами, задачами
        /// </summary>
        /// <param name="tree">Дерево текущее</param>
        public WorkTree(TreeView tree)
        {
            _tree = tree;
            _themaService = new ThemaService();
            _subthemaService = new SubthemaService();
        }

        /// <summary>
        /// Возвращает название типа форма необходимой для создания
        /// </summary>
        /// <returns>Название типа формы</returns>
        public string GetTypeFormNeedToCreateBySelectedNode()
        {
            var currNode = _tree.SelectedNode;
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
            var currNode = _tree.SelectedNode;
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
            var currNode = _tree.SelectedNode;
            var parent = _tree.SelectedNode?.Parent;
            if (parent == null)
            {
                var thema = GetThemaByNode(currNode);
                id = thema.ThemaId;
                return _themaService.Delete;
            }
            var subthema = GetSubthemaByNode(currNode);
            id = subthema.SubthemaId;
            return _subthemaService.Delete;
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
        }

        /// <summary>
        /// Возвращает объект (тема/подтема) по выбранному узлу в дереве
        /// </summary>
        /// <returns></returns>
        public dynamic GetObjectBySelectedNode()
        {
            var currNode = _tree.SelectedNode;
            var parent = _tree.SelectedNode?.Parent;
            if (parent == null)
            {
                return GetThemaByNode(currNode);
            }
            return GetSubthemaByNode(currNode);
        }

        /// <summary>
        /// Вернуть тип для создаваемой формы (по узлу определяется кака форма должна быть создана)
        /// </summary>
        /// <returns>Тип создаваемой формы</returns>
        public Type GetTypeForCreatingForm()
        {
            var typeString = GetTypeFormNeedToCreateBySelectedNode();
            return Type.GetType($"DistanceStudy.Forms.Teacher.{typeString}, DistanceStudy");
        }

        /// <summary>
        /// Получение всех тем в список из БД
        /// </summary>
        private void GetAllObjectsFormDb()
        {
            _themaList?.Clear();
            _subthemaList?.Clear();
            var dbThema = new ThemaRepository();
            _themaList = dbThema.GetAll();
            var dbSubthema = new SubthemaRepository();
            _subthemaList = dbSubthema.GetAll();
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
            }
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
    }
}
