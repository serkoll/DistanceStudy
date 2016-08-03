using System.Collections.Generic;
using System.Windows.Forms;
using DbRepository.Classes.Context;
using DbRepository.Classes.Entities;
using DbRepository.Classes.Repository;

namespace BaseLibrary.Classes
{
    public class WorkWithTree
    {
        #region Константы подсказок и строк в текстовых полях

        public const string HELP_HEAD = "Введите название...";
        public const string HELP_DESCRIPTION = "Введите описание...";
        public const string ALL_TASKS = "Все задачи";

        #endregion
        #region private fields
        // Массивы для хранения тем\подтем
        private static string[][] subthemaNames;
        private static string[][] subthemaDescription;
        private static string[] themaNames;
        private static string[] themaDescription;
        // Рабочий репозиторий работы с бд для тем
        private static ThemaRepository _dbThema;
        // Рабочий репозиторий работы с бд для подтем
        private static SubthemaDb _dbSubthema;
        // Текущая тема
        private static Thema _itemThema;
        // Текущая тема
        private static Subthema _itemSubthema;
        #endregion
        #region public fields
        // Текущее дерево тем\подтем\задач
        public static TreeView tree;
        // Количество доступных тем
        public static int CountThemes { get; set; }
        // Количество доступных подтем
        public static int CountSubthemes { get; set; }
        #endregion
        // Конструктор для инициализации полей
        public static void WorkWithTreeInitializer()
        {
            // Создаем объект общения с бд для тем
            _dbThema = new ThemaRepository();
            // Инициализируем объект темы
            _itemThema = new Thema();
            // Создаем объект общения с бд для подтем
            _dbSubthema = new SubthemaDb();
            // Инициализируем объект подтемы
            _itemSubthema = new Subthema();
            // Инициализация зубчатых массивов для тем и подтем
            subthemaNames = new string[30][];
            for (int i = 0; i < 30; ++i)
            {
                subthemaNames[i] = new string[20];
            }
            subthemaDescription = new string[30][];
            for (int i = 0; i < 30; ++i)
            {
                subthemaDescription[i] = new string[10];
            }
            themaNames = new string[100];
            themaDescription = new string[100];
        }
        /// <summary>
        /// Инициализация переменных и создание/иницализация дерева
        /// </summary>
        /// <param name="itemTreeView"></param>
        public WorkWithTree(TreeView itemTreeView)
        {
            WorkWithTreeInitializer();
            tree = itemTreeView ?? new TreeView();
        }

        /// <summary>
        /// Добавление узлов в дерево и в бд
        /// </summary>
        /// <param name="nameOfThemaSubthema">Имя темы или подтемы</param>
        /// <param name="descriptionOfThemaSubthema">Описание темы или подтемы</param>
        public static void AddNodesToTreeViewDb(string nameOfThemaSubthema, string descriptionOfThemaSubthema)
        {
            string nameThema = nameOfThemaSubthema,
                nameSubthema = nameOfThemaSubthema,
                descThema = descriptionOfThemaSubthema,
                descSubthema = descriptionOfThemaSubthema;
            // Выбираем узел дерева
            TreeNode node = tree.SelectedNode;
            if (node == null)
            {
                // Добавление новой темы в массив строк всех тем
                themaDescription[CountThemes] = descThema;
                themaNames[CountThemes] = nameThema;
                // Добавление в дерево темы
                tree.Nodes.Add(nameThema);
                // Добавление в узел темы - пункт все задачи
                tree.Nodes[CountThemes].Nodes.Add(ALL_TASKS);
                CountThemes++;
                // Заполенение полей объекта текущей темы
                _itemThema.Description = descThema;
                _itemThema.Name = nameThema;
                // Добавление новой темы в бд
                _dbThema.AddThema(_itemThema);
            }
            else
            {
                if (node.Parent == null)
                {
                    subthemaNames[tree.SelectedNode.Index][CountSubthemes] = nameSubthema;
                    subthemaDescription[tree.SelectedNode.Index][CountSubthemes] = descSubthema;
                    CountSubthemes++;
                    // Получение из бд объекта темы, где создается подтема
                    var thema = _dbThema.GetThema(tree.SelectedNode.Text);
                    // Забираем id этой темы
                    _itemSubthema.Id_Thema = thema.Id;
                    // Забираем имя
                    _itemSubthema.Name = nameSubthema;
                    _itemSubthema.Description = descSubthema;
                    // Добавление подтемы в бд
                    _dbSubthema.AddSubthema(_itemSubthema);
                    node.Nodes.Add(nameSubthema);
                }
            }
        }
        /// <summary>
        /// Удаление тем из узлов
        /// </summary>
        public static void DeleteNodesFromTreeView()
        {
            // Выбираем узел дерева
            TreeNode node = tree.SelectedNode;
            if (node.Parent == null)
            {
                var nameThema = tree.SelectedNode.Text;
                // Удаление из дерева
                DeleteThemaFromTreeBd(nameThema);
                // Освобождение ресурсов, обнуление ссылок
                DisposeResources();
                // Заново инициализируем переменные
                WorkWithTreeInitializer();
            }
            else
            {
                var indexSubThema = tree.SelectedNode.Index;
            }
        }
        /// <summary>
        /// Удаление темы из коллекции тем
        /// </summary>
        /// <param name="indexThema">Индекс темы в массиве строк</param>
        private static void DeleteThemaFromTreeBd(string nameThema)
        {
            // Удаление темы из базы данных
            _dbThema.DeleteThema(nameThema);
            // Очистка дерева
            tree.Nodes.Clear();
            // Получаем заново список тем
            // Обновление списка тем в дереве
            UpdateTreeOfThemas(_dbThema.GetAllThemas());
        }
        /// <summary>
        /// Добавление переданной в метод темы(название и описание) в дерево
        /// </summary>
        /// <param name="nameOfThema">Имя темы или подтемы</param>
        /// <param name="descriptionOfThema">Описание темы или подтемы</param>
        public static void AddThemasToTreeView(string nameOfThema, string descriptionOfThema)
        {
            string nameThema = nameOfThema,
                descThema = descriptionOfThema;
            // Выбираем узел дерева
            TreeNode node = null;
            // Добавление новой темы в массив строк всех тем
            themaDescription[CountThemes] = descThema;
            themaNames[CountThemes] = nameThema;
            // Добавление в дерево темы
            tree.Nodes.Add(nameThema);
            // Добавление в узел темы - пункт все задачи
            tree.Nodes[CountThemes].Nodes.Add(ALL_TASKS);
            CountThemes++;
        }
        /// <summary>
        /// Добавление переданной в метод подтемы(название и описание) в дерево
        /// </summary>
        /// <param name="nameOfSubthema">Имя темы или подтемы</param>
        /// <param name="descriptionOfSubthema">Описание темы или подтемы</param>
        public static void AddSubthemasToTreeView(string nameOfSubthema, string descriptionOfSubthema)
        {
            string nameSubthema = nameOfSubthema,
                descSubthema = descriptionOfSubthema;
            TreeNode node = tree.SelectedNode;
            // Добавление новой темы в массив строк всех тем
            subthemaNames[tree.SelectedNode.Index][CountSubthemes] = nameSubthema;
            subthemaDescription[tree.SelectedNode.Index][CountSubthemes] = descSubthema;
            // Добавление в дерево темы
            node.Nodes.Add(nameOfSubthema);
            // Добавление в узел темы - пункт все задачи
            //tree.Nodes[CountThemes].Nodes.Add(ALL_TASKS);
            CountSubthemes++;
        }
        /// <summary>
        /// Метод очищает и заполняет заново дерево
        /// </summary>
        /// <param name="listThemas">Список тем для помещения в дерево</param>
        public static void UpdateTreeOfThemas(IEnumerable<Thema> listThemas)
        {
            // Очистить дерево
            tree.Nodes.Clear();
            // Освободить ресурсы
            DisposeResources();
            // Инициализировать переменные наново
            WorkWithTreeInitializer();
            // Добавить полученные темы в дерево
            foreach (var thema in listThemas)
            {
                AddThemasToTreeView(thema.Name, thema.Description);
            }
        }
        /// <summary>
        /// Отображение в списке имени темы\подтемы и описания
        /// </summary>
        /// <param name="treeNode">Текущий узел</param>
        /// <param name="itemList">Отображение имени и описания</param>
        public static void DisplayOnListView(TreeNode treeNode, ListView itemList)
        {
            //ListViewItem listItem = new ListViewItem();
            //itemList.Columns[2].Text = string.Empty;
            //if (treeNode.Parent == null)
            //{
            //    listItem = new ListViewItem(themaNames[treeNode.Index]);
            //    listItem.SubItems.Add(themaDescription[treeNode.Index]);
            //}
            //else
            //{
            //    if (tree.SelectedNode.Index == 0)
            //    {
            //        // TODO: добавить отображение всего списка задач в список
            //    }
            //    else
            //    {
            //        listItem = new ListViewItem(subthemaNames[tree.SelectedNode.Parent.Index][tree.SelectedNode.Index - 1]);
            //        listItem.SubItems.Add(subthemaDescription[tree.SelectedNode.Parent.Index][tree.SelectedNode.Index - 1]);
            //    }
            //}
            //itemList.Items.Add(listItem);
        }
        /// <summary>
        /// Освобождение ресурсов и обнуление переменных
        /// </summary>
        public static void DisposeResources()
        {
            CountSubthemes = 0;
            CountThemes = 0;
            subthemaNames = null;
            themaNames = null;
            //GC.Collect();
        }
    }
}
