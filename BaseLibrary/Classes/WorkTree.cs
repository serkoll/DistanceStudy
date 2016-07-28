using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DbRepository.Classes.Context;
using DbRepository.Classes.Entities;

namespace BaseLibrary.Classes
{
    public class WorkTree
    {
        // Список тем
        private List<Thema> _themaList;
        // Список подтем
        private List<Subthema> _subthemaList;
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
                tree.Nodes.Clear();
                FillTree();
            }
        }

        /// <summary>
        /// Получение из БД тем и подтем, заполнение ими дерева
        /// </summary>
        private void FillTree()
        {
            var dbThema = new ThemaDb();
            _themaList = dbThema.GetAllThemas().ToList();
            int index = 0;
            foreach (var item in _themaList)
            {
                _tree.Nodes.Add(item.Name);
                _tree.Nodes[index].Nodes.Add("Все задачи");
                _themaDictionary[item.Name] = index;
                GetSubthemasByThemaId(item.Id);
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
                formTask.Dispose();
                formThema.Text = "Создать тему";
                formThema.Show();
                CurrentFlag = true;
            }
            else if (node.Parent != null)
            {
                formThema.Dispose();
                formTask.Show();
            }
            else if (node.Parent == null)
            {
                formTask.Dispose();
                formThema.Text = "Создать подтему";
                formThema.Show();
                CurrentThema = node.Text;
                CurrentFlag = false;
            }
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
                var dbThema = new ThemaDb();
                dbThema.AddThema(new Thema
                {
                    Name = name,
                    Description = description
                });
            }
            else
            {
                var dbSubthema = new SubthemaDb();
                var dbThema = new ThemaDb();
                var currentThema = dbThema.GetThema(CurrentThema);
                dbSubthema.AddSubthema(new Subthema
                {
                    Name = name,
                    Description = description,
                    Id_Thema = currentThema.Id
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
            var dbThema = new ThemaDb();
            _themaList = dbThema.GetAllThemas().ToList();
            int index = 0;
            foreach (var item in _themaList)
            {
                _tree.Nodes.Add(item.Name);
                _tree.Nodes[index].Nodes.Add("Все задачи");
                _themaDictionary[item.Name] = index;
                GetSubthemasByThemaId(item.Id);
                AddSubthemasInNode(index);
                index++;
            }
        }
        /// <summary>
        /// Удаление темы или подтемы
        /// </summary>
        public void Delete(string name)
        {
            if (_tree == null || name == null) return;
            if (CurrentFlag)
            {
                var dbThema = new ThemaDb();
                dbThema.DeleteThema(name);
            }
            else
            {
                var dbSubThema = new SubthemaDb();
                var idSubthema = dbSubThema.GetSubthema(name).Id;
                dbSubThema.DeleteSubthema(idSubthema);
            }
        }
        /// <summary>
        /// Получение подтем по теме
        /// </summary>
        /// <param name="themaId">ID темы</param>
        private void GetSubthemasByThemaId(int themaId)
        {
            var dbSubThema = new SubthemaDb();
            _subthemaList = dbSubThema.GetAllSubthemas()
                .Where(c => c.Id_Thema == themaId)
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
                var dbSubthema = new SubthemaDb();
                return dbSubthema.GetSubthema(node.Text);
            }
            var dbThema = new ThemaDb();
            return dbThema.GetThema(node.Text);
        }

        /// <summary>
        /// Редактировать тему или подтему
        /// </summary>
        /// <param name="node">Узел темы\подтемы</param>
        /// <param name="formThemaSubthema">ФОрма редактирования</param>
        public void EditThemaSubthemaByForm(TreeNode node, Form formThemaSubthema)
        {
            if (node == null) return;
            if (node.Parent == null)
            {
                formThemaSubthema.Text = "Редактировать тему";
                formThemaSubthema.Show();
                CurrentFlag = true;
            }
            if (node.Parent != null)
            {
                formThemaSubthema.Text = "Редактировать подтему";
                formThemaSubthema.Show();
                CurrentThema = node.Parent.Text;
                CurrentFlag = false;
            }
        }

        /// <summary>
        /// Получение темы\подтемы по узлу дерева
        /// </summary>
        /// <param name="node">Узел дерева</param>
        /// <returns>Тема\подтема в виде объекта</returns>
        public dynamic GetThemaOrSubThemaByNode(TreeNode node)
        {
            if (node.Parent == null)
            {
                var themaDb = new ThemaDb();
                return themaDb.GetThema(node.Text);
            }
            if (node.Parent != null)
            {
                var subthemaDb = new SubthemaDb();
                return subthemaDb.GetSubthema(node.Text);
            }
            return null;
        }
    }
}
