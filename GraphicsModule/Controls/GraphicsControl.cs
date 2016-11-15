using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using GraphicsModule.CreateObjects;
using GraphicsModule.Cursors;
using GraphicsModule.Operations;
using GraphicsModule.Geometry.Objects;

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
        private Canvas _canvas;
        /// <summary>
        /// Хранилище графических объектов
        /// </summary>
        private Storage _storage;
        /// <summary>
        /// Класс настроек
        /// </summary>
        private Settings.Settings _settings;
        /// <summary>
        /// Текущее инициализированное правило создания объека
        /// </summary>
        public static ICreate SetObject;
        /// <summary>
        /// Текущая инициализированная операция над графическими объектами
        /// </summary>
        public static IOperation Operations;
        /// <summary>
        /// Класс привязки курсора к сетке
        /// </summary>
        private CursorOnGridMove crMove = new CursorOnGridMove();
        /// <summary>
        /// Инициализация контрола
        /// </summary>
        public GraphicsControl()
        {
            InitializeComponent();
            _ptMenuSelector = new Menu.PointMenuSelector(MainPictureBox); //Создаем меню вариантов для точек
            _lnMenuSelector = new Menu.LineMenuSelector(MainPictureBox); //Создаем меню вариантов для линий
            _sgMenuSelector = new Menu.SegmentMenuSelector(MainPictureBox);
            Controls.Add(_ptMenuSelector); //Добавляем к контролам компонента
            Controls.Add(_lnMenuSelector); //Добавляем к контролам компонента
            Controls.Add(_sgMenuSelector);
        }
        /// <summary>
        /// Импорт графических объектов
        /// </summary>
        /// <param name="coll"></param>
        public void ImportObjects(Collection<IObject> coll)
        {
            _storage.Objects = coll;
            _canvas.ReDraw(_storage);
        }
        /// <summary>
        /// Экспорт графических объектов
        /// </summary>
        /// <returns></returns>
        public Collection<IObject> ExportObjects()
        {
            return _storage.Objects;
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
                SetObject.AddToStorageAndDraw(mousecoords, _canvas.Grid.CenterPoint, _canvas, _settings.DrawS, _storage); //Отрисовываем объект и добавляем его в коллекцию объектов
                _canvas.Update(); //Перерисовывам полотно
            }
            if (Operations != null) //Наличие операции над объектами
            {
                Operations.Execute(mousecoords, _storage, _canvas); // Выполненяем операцию
                _canvas.Update(); //Перерисовываем полотно
            }
        }
        /// <summary>
        /// Перемещение курсора по MainPictureBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            crMove.CursorPointToGridMove(_canvas); // Привязка к сетке
            // Отображение координат текущего положения курсора
            labelValueX.Text = (MainPictureBox.PointToClient(Cursor.Position).X - _canvas.Grid.CenterPoint.X).ToString();
            labelValueY.Text = (MainPictureBox.PointToClient(Cursor.Position).Y - _canvas.Grid.CenterPoint.X).ToString();
        }
        /// <summary>
        /// Вызов контекстного меню точек
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPointsMenu_Click(object sender, EventArgs e)
        {
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
                _canvas.St.GridS.IsDraw = true;
                _canvas.ReDraw(_settings, _storage, MainPictureBox);
            }
            else
            {
                labelStatusGrid.BorderStyle = Border3DStyle.RaisedInner;
                _canvas.St.GridS.IsDraw = false;
                _canvas.ReDraw(_settings, _storage, MainPictureBox);
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
                _canvas.St.AxisS.IsDraw = true;
                _canvas.ReDraw(_settings, _storage, MainPictureBox);
            }
            else
            {
                labelSatusAxis.BorderStyle = Border3DStyle.RaisedInner;
                _canvas.St.AxisS.IsDraw = false;
                _canvas.ReDraw(_settings, _storage, MainPictureBox);
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
            _canvas.ReDraw(_settings, _storage, MainPictureBox);
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
                _settings.DrawS.LinkLineSettings.IsDraw = true;
                _canvas.ReDraw(_settings, _storage, MainPictureBox);
            }
            else
            {
                labelStatusLinkLine.BorderStyle = Border3DStyle.RaisedInner;
                _settings.DrawS.LinkLineSettings.IsDraw = false;
                _canvas.ReDraw(_settings, _storage, MainPictureBox);
            }
        }
        /// <summary>
        /// Вызов меню настроек графического редактора
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSettings_Click(object sender, EventArgs e)
        {
            var f = new Settings.Forms.SettingsForm();
            f.ShowDialog();
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
            _sgMenuSelector.Location = new Point(graphicsToolBarStrip.Size.Width, graphicsToolBarStrip.Location.Y + buttonPointsMenu.Size.Height + buttonLinesMenu.Size.Height);
            _sgMenuSelector.Visible = true;
            _sgMenuSelector.BringToFront();
        }

        private void GraphicsControl_Load(object sender, EventArgs e)
        {
            _settings = new Settings.Settings(); //Получаем экземпляр настроек
            _canvas = new Canvas(_settings, MainPictureBox); // Инициализируем полотно отрисовки
            _storage = new Storage(); // инициализируем хранилище графических объектов
        }
    }
}

