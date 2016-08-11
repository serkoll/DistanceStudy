using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DbRepository.Classes.Context;
using DbRepository.Classes.Repository;
using DbRepository.Context;

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

        /// <summary>
        /// Конструктор. Заполняет из БД дерево темами, подтемами, задачами
        /// </summary>
        /// <param name="tree">Дерево текущее</param>
        public WorkTree(TreeView tree)
        {
            _tree = tree;
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
            foreach(var item in _themaList)
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
            foreach(var subthema in subthemasOfThema)
            {
                var index = _tree.Nodes.Count;
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
    }
}
