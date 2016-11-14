using System;
using System.Drawing;
using System.Windows.Forms;
using GraphicsModule.CreateObjects;
using GraphicsModule.Cursors;
using GraphicsModule.Operations;

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
        private Controls.Menu.PointMenuSelector ptMenuSelector;
        /// <summary>
        /// Меню создания линий
        /// </summary>
        private Controls.Menu.LineMenuSelector lnMenuSelector;
        /// <summary>
        /// Меню создания отрезков
        /// </summary>
        private Controls.Menu.SegmentMenuSelector sgMenuSelector;
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
        private Setting.Settings _settings;
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
            _settings = new Setting.Settings(); //Получаем экземпляр настроек
            ptMenuSelector = new Controls.Menu.PointMenuSelector(MainPictureBox); //Создаем меню вариантов для точек
            lnMenuSelector = new Controls.Menu.LineMenuSelector(MainPictureBox); //Создаем меню вариантов для линий
            sgMenuSelector = new Controls.Menu.SegmentMenuSelector(MainPictureBox);
            Controls.Add(ptMenuSelector); //Добавляем к контролам компонента
            Controls.Add(lnMenuSelector); //Добавляем к контролам компонента
            Controls.Add(sgMenuSelector);
        }
        /// <summary>
        /// Загрузка формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GraphicsControl_Load(object sender, EventArgs e)
        {
            _canvas = new Canvas(_settings, MainPictureBox); // Инициализируем полотно отрисовки
            _storage = new Storage(); // инициализируем хранилище графических объектов
            var rc = _canvas.Graphics.ClipBounds;
        }
        /// <summary>
        /// Скрывает выпадающее меню для графических примитивов
        /// </summary>
        private void HideMenus()
        {
            ptMenuSelector.Visible = false;
            lnMenuSelector.Visible = false;
            sgMenuSelector.Visible = false;
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
                SetObject.AddToStorageAndDraw(mousecoords, _canvas.Grid.Center, _canvas, _settings.DrawS, _storage); //Отрисовываем объект и добавляем его в коллекцию объектов
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
            labelValueX.Text = (MainPictureBox.PointToClient(Cursor.Position).X - _canvas.Grid.Center.X).ToString();
            labelValueY.Text = (MainPictureBox.PointToClient(Cursor.Position).Y - _canvas.Grid.Center.X).ToString();
        }
        /// <summary>
        /// Вызов контекстного меню точек
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPointsMenu_Click(object sender, EventArgs e)
        {
            ptMenuSelector.Location = new Point(graphicsToolBarStrip.Size.Width, graphicsToolBarStrip.Location.Y);
            ptMenuSelector.Visible = true;
            ptMenuSelector.BringToFront();
        }
        /// <summary>
        /// Вызов контекстного меню линий
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnPointsMenu_Click(object sender, EventArgs e)
        {
            lnMenuSelector.Location = new Point(graphicsToolBarStrip.Size.Width, graphicsToolBarStrip.Location.Y + buttonPointsMenu.Size.Height);
            lnMenuSelector.Visible = true;
            lnMenuSelector.BringToFront();
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
                _canvas.Grid.Setting.IsDraw = true;
                _canvas.ReDraw(_settings, _storage, MainPictureBox);
            }
            else
            {
                labelStatusGrid.BorderStyle = Border3DStyle.RaisedInner;
                _canvas.Grid.Setting.IsDraw = false;
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
                _canvas.Axis.Setting.IsDraw = true;
                _canvas.ReDraw(_settings, _storage, MainPictureBox);
            }
            else
            {
                labelSatusAxis.BorderStyle = Border3DStyle.RaisedInner;
                _canvas.Axis.Setting.IsDraw = false;
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
            var f = new GraphicsModule.Settings.Forms.SettingsForm();
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
            sgMenuSelector.Location = new Point(graphicsToolBarStrip.Size.Width, graphicsToolBarStrip.Location.Y + buttonPointsMenu.Size.Height + buttonLinesMenu.Size.Height);
            sgMenuSelector.Visible = true;
            sgMenuSelector.BringToFront();
        }
    }
}

