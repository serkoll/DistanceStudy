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
        // Полу ключ - значение соответствие индекса в дереве имени темы
        private readonly Dictionary<string, int> _themaDictionary = new Dictionary<string, int>();
        // Текущее дерево
        private readonly TreeView _tree;
        // Флаг (true - тема, false - подтема)
        private static bool CurrentFlag { get; set; }
        // Текущее название темы для подтемы
        private static string CurrentThema { get; set; }

        /// <summary>
        /// Конструктор. Заполняет из БД дерево темами, подтемами, задачами
        /// </summary>
        /// <param name="tree">Дерево текущее</param>
        public WorkTree(TreeView tree)
        {
            if (tree != null)
            {
                _tree = tree;
            }
        }

        /// <summary>
        /// Получение из БД тем и подтем, заполнение ими дерева
        /// </summary>
        private void FillTree()
        {
            var dbThema = new ThemaRepository();
            _themaList = dbThema.GetAllThemas().ToList();
            int index = 0;
            foreach (var item in _themaList)
            {
                _tree.Nodes.Add(item.Name);
                _tree.Nodes[index].Nodes.Add("Все задачи");
                _themaDictionary[item.Name] = index;
                GetSubthemasByThemaId(item.ThemaId);
                AddSubthemasInNode(index);
                index++;
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
        /// Отображение формы для создания темы/подтемы/задачи
        /// </summary>
        /// <param name="node">Текущий узел</param>
        /// <param name="formThema">Форма для создания темы и подтемы</param>
        /// <param name="formTask">Форма для создания задания</param>
        public void CreateFormBySelectedNode(TreeNode node, Form formThema, Form formTask)
        {
            if (node == null)
            {
                formThema.Text = "Создать тему";
                formThema.Show();
                CurrentFlag = true;
            }
            else if (node.Parent != null)
            {
                formTask.Show();
            }
            else if (node.Parent == null)
            {
                formThema.Text = "Создать подтему";
                formThema.Show();
                CurrentThema = node.Text;
                CurrentFlag = false;
            }
        }

        public void CreateEditFormBySelectedNode(TreeNode node, Form formThema, Form formTask)
        {
            
        }

    /// <summary>
        /// Создание темы/подтемы
        /// </summary>
        /// <param name="name">Имя темы/подтемы</param>
        /// <param name="description">Описание темы/подтемы</param>
        public void CreateThemaSubthemaByForm(string name, string description)
        {
            if (CurrentFlag)
            {
                var dbThema = new ThemaRepository();
                dbThema.AddThema(new Thema
                {
                    Name = name,
                    Description = description
                });
            }
            else
            {
                var dbSubthema = new SubthemaRepository();
                var dbThema = new ThemaRepository();
                var currentThema = dbThema.GetThema(CurrentThema);
                dbSubthema.AddSubthema(new SubThema
                {
                    Name = name,
                    Description = description,
                    ThemaId = currentThema.ThemaId
                });
            }
        }

        /// <summary>
        /// Обновление дерева тем и подтем
        /// </summary>
        public void UpdateTree()
        {
            if (_tree == null) return;
            _tree.Nodes.Clear();
            var dbThema = new ThemaRepository();
            _themaList = dbThema.GetAllThemas().ToList();
            int index = 0;
            foreach (var item in _themaList)
            {
                _tree.Nodes.Add(item.Name);
                _tree.Nodes[index].Nodes.Add("Все задачи");
                _themaDictionary[item.Name] = index;
                GetSubthemasByThemaId(item.ThemaId);
                AddSubthemasInNode(index);
                index++;
            }
        }
        /// <summary>
        /// Delete thema or subthema
        /// </summary>
        public void Delete(string name)
        {
            if (_tree == null || name == null) return;
            var dbThema = new ThemaRepository();
            var dbSubThema = new SubthemaRepository();
            if (_tree.SelectedNode.Parent == null)
                dbThema.DeleteThema(name);
            if (_tree.SelectedNode.Parent != null)
            {
                var idSubthema = dbSubThema.GetSubthema(name).SubthemaId;
                dbSubThema.DeleteSubthema(idSubthema);
            }
        }
        /// <summary>
        /// Получение подтем по теме
        /// </summary>
        /// <param name="themaId">ID темы</param>
        private void GetSubthemasByThemaId(int themaId)
        {
            var dbSubThema = new SubthemaRepository();
            _subthemaList = dbSubThema.GetAllSubthemas()
                .Where(c => c.ThemaId == themaId)
                .ToList();
        }
        /// <summary>
        /// Получит объект темы по имени
        /// </summary>
        /// <param name="node">Выбранный узел дерева</param>
        /// <returns></returns>
        public dynamic GetThemaByNode(TreeNode node)
        {
            if (node.Parent != null)
            {
                var dbSubthema = new SubthemaRepository();
                return dbSubthema.GetSubthema(node.Text);
            }
            var dbThema = new ThemaRepository();
            return dbThema.GetThema(node.Text);
        }
    }
}
