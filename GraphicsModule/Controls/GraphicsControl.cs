using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using GraphicsModule.Cursors;
using System.IO;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Interfaces;
using GraphicsModule.Settings.Forms;

namespace GraphicsModule.Controls
{
    /// <summary>
    /// Класс графического редактора
    /// </summary>
    public partial class GraphicsControl : UserControl
    {
        /// <summary>
        /// Меню создания точек
        /// </summary>
        private readonly Menu.PointMenuSelector _ptMenuSelector;
        /// <summary>
        /// Меню создания линий
        /// </summary>
        private readonly Menu.LineMenuSelector _lnMenuSelector;
        /// <summary>
        /// Меню создания отрезков
        /// </summary>
        private readonly Menu.SegmentMenuSelector _sgMenuSelector;
        /// <summary>
        /// Полотно отрисовки
        /// </summary>
        private Canvas.Canvas _canvas;
        /// <summary>
        /// Хранилище графических объектов
        /// </summary>
        private Storage _storage;
        /// <summary>
        /// Класс настроек
        /// </summary>
        private readonly Settings.Settings _settings;
        /// <summary>
        /// Текущее инициализированное правило создания объека
        /// </summary>
        public static ICreate SetObject;
        /// <summary>
        /// Текущая инициализированная операция над графическими объектами
        /// </summary>
        public static IOperation Operations;
        /// <summary>
        /// Генератор имен объектов
        /// </summary>
        public static NamesGenerator NmGenerator;
        /// <summary>
        /// Класс привязки курсора к сетке
        /// </summary>
        private readonly CursorOnGridMove _crMove = new CursorOnGridMove();
        /// <summary>
        /// Путь к настройкам редактора
        /// </summary>
        private const string SettingsFileName = "config.cfg";
        /// <summary>
        /// Инициализация контрола
        /// </summary>
        public GraphicsControl()
        {
            InitializeComponent();
            if (File.Exists(SettingsFileName))
            {
                _settings = new Settings.Settings().Deserialize(SettingsFileName); //Получаем экземпляр настроек
                FormSettings.ValueS = _settings;
            }
            else
            {
                _settings = new Settings.Settings();
                _settings.Serialize(SettingsFileName);
                FormSettings.ValueS = _settings;
            }
            MainPictureBox.BackColor = _settings.BackgroundColor;
            NmGenerator = new NamesGenerator(true, 0, _settings);
            _ptMenuSelector = new Menu.PointMenuSelector(MainPictureBox, buttonPointsMenu, statusStripObjectMenu); //Создаем меню вариантов для точек
            _lnMenuSelector = new Menu.LineMenuSelector(MainPictureBox, buttonLinesMenu, statusStripObjectMenu); //Создаем меню вариантов для линий
            _sgMenuSelector = new Menu.SegmentMenuSelector(MainPictureBox, buttonSegmentMenu, statusStripObjectMenu); //Создаем меню вариантов для отрезков
            Controls.Add(_ptMenuSelector); //Добавляем к контролам компонента
            Controls.Add(_lnMenuSelector); //Добавляем к контролам компонента
            Controls.Add(_sgMenuSelector); //Добавляем к контролам компонента
        }
        /// <summary>
        /// Импорт графических объектов
        /// </summary>
        /// <param name="coll"></param>
        public void ImportObjects(Collection<IObject> coll)
        {
            if(_storage == null) _storage = new Storage();
            _storage.Objects = coll;
            _canvas.Update(_storage);
        }
        /// <summary>
        /// Экспорт графических объектов
        /// </summary>
        /// <returns></returns>
        public Collection<IObject> ExportObjects()
        {
            return _storage.Objects;
        }
        public Collection<IObject> ExportSelected()
        {
            return _storage.SelectedObjects;
        }
        /// <summary>
        /// Скрывает выпадающее меню для графических примитивов
        /// </summary>
        private void HideMenus()
        {
            _ptMenuSelector.Visible = false;
            _lnMenuSelector.Visible = false;
            _sgMenuSelector.Visible = false;
        }
        /// <summary>
        /// Включение/выключение привязки к сетке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelCursorToGridFixation_Click(object sender, EventArgs e)
        {
            if (labelCursorToGridFixation.BorderStyle == Border3DStyle.RaisedInner)
            {
                labelCursorToGridFixation.BorderStyle = Border3DStyle.SunkenOuter;
                CursorOnGridMove.ToGridFixation = true;
            }
            else
            {
                labelCursorToGridFixation.BorderStyle = Border3DStyle.RaisedInner;
                CursorOnGridMove.ToGridFixation = false;
            }
        }
        /// <summary>
        /// Действие при нажатии левой кнопки мыши на MainPictureBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainPictureBox_MouseDown(object sender, EventArgs e)
        {
            HideMenus(); // скрываем открытые меню
            var mousecoords = MainPictureBox.PointToClient(MousePosition);  //Получаем координаты курсора мыши
            if (SetObject != null) //Контроль существования объекта
            {
                SetObject.AddToStorageAndDraw(mousecoords, _canvas.CenterSystemPoint, _canvas, _settings.DrawS, _storage); //Отрисовываем объект и добавляем его в коллекцию объектов
                _canvas.Refresh(); //Перерисовывам полотно
            }
            if (Operations != null) //Наличие операции над объектами
            {
                Operations.Execute(mousecoords, _storage, _canvas); // Выполненяем операцию
                _canvas.Refresh(); //Перерисовываем полотно
            }
        }
        /// <summary>
        /// Перемещение курсора по MainPictureBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            _crMove.CursorPointToGridMove(_canvas); // Привязка к сетке
            labelValueX.Text = (MainPictureBox.PointToClient(Cursor.Position).X - _canvas.CenterSystemPoint.X).ToString();
            labelValueY.Text = (MainPictureBox.PointToClient(Cursor.Position).Y - _canvas.CenterSystemPoint.Y).ToString();
        }
        /// <summary>
        /// Вызов контекстного меню точек
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPointsMenu_Click(object sender, EventArgs e)
        {
            HideMenus();
            _ptMenuSelector.Location = new Point(graphicsToolBarStrip.Size.Width, graphicsToolBarStrip.Location.Y);
            _ptMenuSelector.Visible = true;
            _ptMenuSelector.BringToFront();
        }
        /// <summary>
        /// Вызов контекстного меню линий
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnPointsMenu_Click(object sender, EventArgs e)
        {
            HideMenus();
            _lnMenuSelector.Location = new Point(graphicsToolBarStrip.Size.Width, graphicsToolBarStrip.Location.Y + buttonPointsMenu.Size.Height);
            _lnMenuSelector.Visible = true;
            _lnMenuSelector.BringToFront();
        }
        /// <summary>
        /// Включить/выключить сетку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelStatusGrid_Click(object sender, EventArgs e)
        {
            if (labelStatusGrid.BorderStyle == Border3DStyle.RaisedInner)
            {
                labelStatusGrid.BorderStyle = Border3DStyle.SunkenOuter;
                _canvas.Setting.GridS.IsDraw = true;
                _canvas.Update(_storage);
            }
            else
            {
                labelStatusGrid.BorderStyle = Border3DStyle.RaisedInner;
                _canvas.Setting.GridS.IsDraw = false;
                _canvas.Update(_storage);
            }
        }
        /// <summary>
        /// Включить оси
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelSatusAxis_Click(object sender, EventArgs e)
        {
            if (labelSatusAxis.BorderStyle == Border3DStyle.RaisedInner)
            {
                labelSatusAxis.BorderStyle = Border3DStyle.SunkenOuter;
                _canvas.Setting.AxisS.IsDraw = true;
                _canvas.Update(_storage);
            }
            else
            {
                labelSatusAxis.BorderStyle = Border3DStyle.RaisedInner;
                _canvas.Setting.AxisS.IsDraw = false;
                _canvas.Update(_storage);
            }
        }
        /// <summary>
        /// Выбрать графические объекты ( Кнопка "Выбрать" )
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            SetObject = null;
            Operations = new SelectObject();
            MainPictureBox.Cursor = System.Windows.Forms.Cursors.Hand; // Указание вида курсора
        }
        /// <summary>
        /// Удалить выбранный объект ( Кнопка "Стереть" )
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            SetObject = null;
            Operations = new Erase();
            MainPictureBox.Cursor = System.Windows.Forms.Cursors.Hand; // Указание вида курсора
        }
        /// <summary>
        /// Удалить все объекты ( Кнопка "Очистить всё" )
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClearAll_Click(object sender, EventArgs e)
        {
            _storage.ClearAllCollections();
            _canvas.Update(_storage);
            SetObject = null;
            MainPictureBox.Cursor = System.Windows.Forms.Cursors.Default;
        }
        /// <summary>
        /// Удаление выбранных объектов ( Кнопка "Удалить выбранное")
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonErase_Click(object sender, EventArgs e)
        {
            SetObject = null;
            Operations = null;
            new DeleteSelected().Execute(_storage, _canvas);
            MainPictureBox.Cursor = System.Windows.Forms.Cursors.Default;
        }
        /// <summary>
        /// Обработчик события нажатия некоторых кнопок ( Кнопка "ESC") 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Operations = null;
                SetObject = null;
                MainPictureBox.Cursor = System.Windows.Forms.Cursors.Default;
                statusStripObjectMenu.Visible = false;
            }
        }
        /// <summary>
        /// Отрисовка линий связи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelStatusLinkLine_Click(object sender, EventArgs e)
        {
            if (labelStatusLinkLine.BorderStyle == Border3DStyle.RaisedInner)
            {
                labelStatusLinkLine.BorderStyle = Border3DStyle.SunkenOuter;
                _canvas.Setting.DrawS.LinkLineSettings.IsDraw = true;
                _canvas.Update(_storage);
            }
            else
            {
                labelStatusLinkLine.BorderStyle = Border3DStyle.RaisedInner;
                _canvas.Setting.DrawS.LinkLineSettings.IsDraw = false;
                _canvas.Update(_storage);
            }
        }
        /// <summary>
        /// Вызов меню настроек графического редактора
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSettings_Click(object sender, EventArgs e)
        {
            var f = new FormSettings();
            f.ShowDialog();
            _canvas.Update(_storage);
            MainPictureBox.BackColor = _settings.BackgroundColor;
        }
        /// <summary>
        /// Копирование объектов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCopy_Click(object sender, EventArgs e)
        {
            SetObject = null;
            Operations = new Copy();
            MainPictureBox.Cursor = System.Windows.Forms.Cursors.Hand; // Указание вида курсора
        }
        private void toolStripButton_Scale_Click(object sender, EventArgs e)
        {

        }
        private void buttonSegmentMenu_Click(object sender, EventArgs e)
        {
            HideMenus();
            _sgMenuSelector.Location = new Point(graphicsToolBarStrip.Size.Width, graphicsToolBarStrip.Location.Y + buttonPointsMenu.Size.Height + buttonLinesMenu.Size.Height);
            _sgMenuSelector.Visible = true;
            _sgMenuSelector.BringToFront();
        }
        private void GraphicsControl_Load(object sender, EventArgs e)
        {
            _canvas = new Canvas.Canvas(_settings, MainPictureBox); // Инициализируем полотно отрисовки
            if(_storage == null) _storage = new Storage(); // инициализируем хранилище графических объектов
        }
        private void solidWorksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sldWorksObject = new SolidworksInteraction.SldWorksInteraction();
            if (sldWorksObject.Connect())
            {
                sldWorksObject.SetActiveDocument();
                sldWorksObject.ImportGrid(_canvas.Bckground.Grid);
                sldWorksObject.ImportAxis(_canvas.Bckground.Axis);
                sldWorksObject.ImportCollectionToActiveDoc(_storage.Objects, _canvas.Setting.DrawS);
            }
            else
            {
                MessageBox.Show(@"Не удалось подключиться к SolidWorks");
            }
        }

        private void GraphicsControl_Resize(object sender, EventArgs e)
        { 
            //if(_storage != null)
            //_canvas.Update(_storage);
        }
        private void левыйВерхнийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NmGenerator.Position = 0;
        }
        private void правыйВерхнийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NmGenerator.Position = 1;
        }

        private void левыйНижнийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NmGenerator.Position = 2;
        }
        private void правыйНижнийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NmGenerator.Position = 3;
        }
    }
}

