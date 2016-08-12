using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DbRepository.Classes.Context;
using DbRepository.Classes.Repository;
using DbRepository.Context;
using Service.Services;
using System;
using Microsoft.CSharp.RuntimeBinder;

namespace BaseLibrary.Classes
{
    public class WorkTree
    {
        // Список тем
        private List<Thema> _themaList;
        // Список подтем
        private List<SubThema> _subthemaList;
        // Текущее дерево
        private readonly TreeView _tree;
        // Сервис по добавлению тем
        private ThemaService _themaService;
        // Сервис по добавлению тем
        private SubthemaService _subthemaService;

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
        /// Метод, возвращающий ссылку на метод по добавлению нужного объекта (тема/подтема)
        /// </summary>
        /// <returns>Метод по добавлению из сервиса</returns>
        public Action<int, string, string> GetMethodForCreateNeededObject(out int id)
        {
            var currNode = _tree.SelectedNode;
            var parent = _tree.SelectedNode?.Parent;
            if (currNode == null)
            {
                id = 0;
                return _themaService.Add;
            }
            id = GetThemaByNode(currNode).ThemaId;
            return _subthemaService.Add;
        }

        /// <summary>
        /// Метод возвращает ссылку на метод по редактированию темы/подтемы
        /// </summary>
        /// <param name="item">Тема/подтема для обновления</param>
        /// <param name="id">ИД нужного обекта</param>
        /// <returns>Метод обновления из сервиса</returns>
        public Action<int, string, string> GetMethodForUpdateNeededObject(dynamic item, out int id)
        {
            id = 0;
            try
            {
                if (item is Thema)
                {
                    id = item.ThemaId;
                    return _themaService.Update;
                }
                if (item is SubThema)
                {
                    id = item.SubthemaId;
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
        /// Добавление в узел темы подтему
        /// </summary>
        /// <param name="index">Индекс текущего узла</param>
        private void AddSubthemasInNode(int index)
        {
            if (_subthemaList == null) return;
            foreach (var item in _subthemaList)
            {
                _tree.Nodes[index].Nodes.Add(item.Name);
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
