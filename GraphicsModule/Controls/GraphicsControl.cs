using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GraphicsModule.Cursors;
using System.IO;
using GraphicsModule.Configuration;
using GraphicsModule.Enums;
using GraphicsModule.Forms;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Interfaces;

namespace GraphicsModule.Controls
{
    /// <summary>
    /// Класс графического редактора
    /// </summary>
    public partial class GraphicsControl : UserControl
    {
        #region Properties

        public static string StaticName;

        #region Menus
        /// <summary>
        /// Меню создания точек
        /// </summary>
        private Menu.PointMenuSelector _ptMenuSelector;
        /// <summary>
        /// Меню создания линий
        /// </summary>
        private Menu.LineMenuSelector _lnMenuSelector;
        /// <summary>
        /// Меню создания отрезков
        /// </summary>
        private Menu.SegmentMenuSelector _sgMenuSelector;
        /// <summary>
        /// Меню создания плоскостей
        /// </summary>
        private Menu.PlaneMenuSelector _plMenuSelector;
        #endregion

        /// <summary>
        /// Полотно отрисовки
        /// </summary>
        private Blueprint _blueprint;

        /// <summary>
        /// Хранилище графических объектов
        /// </summary>
        private Storage _storage;

        /// <summary>
        /// Класс настроек
        /// </summary>
        private Settings _settings;

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
        public static NamesGenerator NamesGenerator;

        /// <summary>
        /// Класс привязки курсора к сетке
        /// </summary>
        private readonly CursorOnGridMove _crMove = new CursorOnGridMove();

        /// <summary>
        /// Путь к настройкам редактора
        /// </summary>
        private const string SettingsFileName = "config.cfg";

        #endregion

        /// <summary>
        /// Инициализация контрола
        /// </summary>
        public GraphicsControl()
        {
            InitializeComponent();
            LoadSettings();
            InitializeMenu();

            //var objectPanel = new ObjectPanel();

            GraphicsControl.NamesGenerator = new NamesGenerator(true, 0, _settings);
            _storage = new Storage();

            //objectPanel.Show(dockPanel1);
        }
        /// <summary>
        /// Загрузка общих настроек настроек
        /// </summary>
        public void LoadSettings()
        {
            if (File.Exists(SettingsFileName))
            {
                _settings = new Settings().Deserialize(SettingsFileName);
                GraphicsControlSettingsForm.CurrentSettings = _settings;
            }
            else
            {
                _settings = new Settings();
                _settings.Serialize(SettingsFileName);
                GraphicsControlSettingsForm.CurrentSettings = _settings;
            }
            MainPictureBox.BackColor = _settings.BackgroundColor;
        }

        /// <summary>
        /// Ининциализация панелей создания объекта
        /// </summary>
        public void InitializeMenu()
        {
            _ptMenuSelector = new Menu.PointMenuSelector(MainPictureBox, buttonPointsMenu, ObjectsPropertyMenu, _settings.PrimitivesAcces.Points);
            _lnMenuSelector = new Menu.LineMenuSelector(MainPictureBox, buttonLinesMenu, ObjectsPropertyMenu, _settings.PrimitivesAcces.Lines);
            _sgMenuSelector = new Menu.SegmentMenuSelector(MainPictureBox, buttonSegmentMenu, ObjectsPropertyMenu, _settings.PrimitivesAcces.Segments);
            _plMenuSelector = new Menu.PlaneMenuSelector(MainPictureBox, buttonPlanesMenu, ObjectsPropertyMenu, _settings.PrimitivesAcces.Planes);
            AddMenus();
            SetPrimitivesButtonsEnabled();
        }

        private void AddMenus()
        {
            Controls.AddRange(new Control[] {
                    _ptMenuSelector,
                    _lnMenuSelector,
                    _sgMenuSelector,
                    _plMenuSelector});
        }

        private void SetPrimitivesButtonsEnabled()
        {
            this.buttonPointsMenu.Enabled = _settings.PrimitivesAcces.Points.IsPointsEnabled;
            this.buttonLinesMenu.Enabled = _settings.PrimitivesAcces.Lines.IsLinesEnabled;
            this.buttonSegmentMenu.Enabled = _settings.PrimitivesAcces.Segments.IsSegmentsEnabled;
            this.buttonPlanesMenu.Enabled = _settings.PrimitivesAcces.Planes.IsPlanesEnabled;
        }
        public void SetAccess()
        {
            this.buttonPointsMenu.Enabled = _settings.PrimitivesAcces.Points.IsPointsEnabled;
            this.buttonLinesMenu.Enabled = _settings.PrimitivesAcces.Lines.IsLinesEnabled;
            this.buttonSegmentMenu.Enabled = _settings.PrimitivesAcces.Segments.IsSegmentsEnabled;
            this.buttonPlanesMenu.Enabled = _settings.PrimitivesAcces.Planes.IsPlanesEnabled;
            _ptMenuSelector.SetAccess(_settings.PrimitivesAcces.Points);
            _lnMenuSelector.SetAccess(_settings.PrimitivesAcces.Lines);
            _plMenuSelector.SetAccess(_settings.PrimitivesAcces.Planes);
            _sgMenuSelector.SetAccess(_settings.PrimitivesAcces.Segments);
        }

        private void GraphicsControl_Load(object sender, EventArgs e)
        {
            _blueprint = new Blueprint(_settings, MainPictureBox);

            if (_storage == null)
            {
                var msg = "Ошибка при инициализации хранилища данных";
                throw new ArgumentNullException($"{_storage}", msg);
            }
        }

        //TODO: при переходе на несколько чертежей изменить
        private void GraphicsControl_Resize(object sender, EventArgs e)
        {
            if (_storage == null || _blueprint == null) return;
            _blueprint.CalculateBackground();
            _blueprint.Update(_storage);
        }

        #region Other operations
        /// <summary>
        /// Импорт графических объектов
        /// </summary>
        /// <param name="coll"></param>
        public void ImportObjects(IList<IObject> coll)
        {
            if (_storage == null) _storage = new Storage(coll);
            _blueprint.Update(_storage);
        }
        /// <summary>
        /// Экспорт графических объектов
        /// </summary>
        /// <returns></returns>
        public IList<IObject> ExportObjects()
        {
            return _storage.Objects;
        }

        public IList<IObject> ExportSelected()
        {
            return _storage.SelectedObjects;
        }

        #endregion

        #region UI help functions
        /// <summary>
        /// Скрывает выпадающее меню для графических примитивов
        /// </summary>
        private void HideSelectorMenus()
        {
            Focus();
            _ptMenuSelector.Visible = false;
            _lnMenuSelector.Visible = false;
            _sgMenuSelector.Visible = false;
            _plMenuSelector.Visible = false;
        }

        private void HidePropertyBuidMenu()
        {
            ObjectsPropertyMenu.Visible = false;
        }

        #endregion

        #region Workspace buttons events
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
                _blueprint.Settings.DrawSettings.LinkLinesSettings.IsDraw = true;
                _blueprint.Update(_storage);
            }
            else
            {
                labelStatusLinkLine.BorderStyle = Border3DStyle.RaisedInner;
                _blueprint.Settings.DrawSettings.LinkLinesSettings.IsDraw = false;
                _blueprint.Update(_storage);
            }
        }
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
        /// Включить/выключить сетку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelStatusGrid_Click(object sender, EventArgs e)
        {
            if (labelStatusGrid.BorderStyle == Border3DStyle.RaisedInner)
            {
                labelStatusGrid.BorderStyle = Border3DStyle.SunkenOuter;
                _blueprint.Settings.GridSettings.IsDraw = true;
                _blueprint.Update(_storage);
            }
            else
            {
                labelStatusGrid.BorderStyle = Border3DStyle.RaisedInner;
                _blueprint.Settings.GridSettings.IsDraw = false;
                _blueprint.Update(_storage);
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
                _blueprint.Settings.AxisSettings.IsDraw = true;
                _blueprint.Update(_storage);
            }
            else
            {
                labelSatusAxis.BorderStyle = Border3DStyle.RaisedInner;
                _blueprint.Settings.AxisSettings.IsDraw = false;
                _blueprint.Update(_storage);
            }
        }

        #endregion

        #region Control and PictureBox events

        private void MainPictureBox_MouseDown(object sender, EventArgs e)
        {
            HideSelectorMenus(); // скрываем открытые меню
            var mousecoords = MainPictureBox.PointToClient(MousePosition);  //Получаем координаты курсора мыши
            if (SetObject != null) //Контроль существования объекта
            {
                SetObject.AddToStorageAndDraw(mousecoords, _blueprint.CenterSystemPoint, _blueprint, _settings.DrawSettings, _storage); //Отрисовываем объект и добавляем его в коллекцию объектов
                //TODO: нужно ли
                _blueprint.Refresh(); //Перерисовывам полотно
            }
            if (Operations != null) //Наличие операции над объектами
            {
                Operations.Execute(mousecoords, _storage, _blueprint); // Выполненяем операцию
                _blueprint.Refresh(); //Перерисовываем полотно
            }
        }

        private void MainPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            _crMove.CursorPointToGridMove(_blueprint); // Привязка к сетке
            labelValueX.Text = (MainPictureBox.PointToClient(Cursor.Position).X - _blueprint.CenterSystemPoint.X).ToString();
            labelValueY.Text = (MainPictureBox.PointToClient(Cursor.Position).Y - _blueprint.CenterSystemPoint.Y).ToString();
        }

        private void GraphicsControl_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    {
                        _storage.TempObjects.Clear();
                        SetObject = null;
                        Operations = null;
                        _storage.SelectedObjects.Clear();
                        _blueprint.Update(_storage);
                        HideSelectorMenus();
                        HidePropertyBuidMenu();
                        MainPictureBox.Cursor = System.Windows.Forms.Cursors.Default;
                        break;
                    }
            }
        }
        #endregion

        #region ObjectsBuildMenu events
        /// <summary>
        /// Вызов контекстного меню точек
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPointsMenu_Click(object sender, EventArgs e)
        {
            HideSelectorMenus();
            _storage.ClearTempCollections();
            _blueprint.Update(_storage);
            _ptMenuSelector.Location = new Point(ObjectsBuildMenu.Size.Width, ObjectsBuildMenu.Location.Y);
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
            HideSelectorMenus();
            _storage.ClearTempCollections();
            _blueprint.Update(_storage);
            _lnMenuSelector.Location = new Point(ObjectsBuildMenu.Size.Width, ObjectsBuildMenu.Location.Y + buttonPointsMenu.Size.Height);
            _lnMenuSelector.Visible = true;
            _lnMenuSelector.BringToFront();
        }
        private void buttonSegmentMenu_Click(object sender, EventArgs e)
        {
            HideSelectorMenus();
            _storage.ClearTempCollections();
            _blueprint.Update(_storage);
            _sgMenuSelector.Location = new Point(ObjectsBuildMenu.Size.Width, ObjectsBuildMenu.Location.Y + buttonPointsMenu.Size.Height + buttonLinesMenu.Size.Height);
            _sgMenuSelector.Visible = true;
            _sgMenuSelector.BringToFront();
        }
        private void buttonPlaneMenu_Click(object sender, EventArgs e)
        {
            HideSelectorMenus();
            _plMenuSelector.Location = new Point(ObjectsBuildMenu.Size.Width, ObjectsBuildMenu.Location.Y + buttonPointsMenu.Height * (ObjectsBuildMenu.Items.Count - 1));
            _plMenuSelector.Visible = true;
            _plMenuSelector.BringToFront();
        }
        #endregion

        #region BaseOperationsMenu events
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
            _blueprint.Update(_storage);
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
            new DeleteSelected().Execute(_storage, _blueprint);
            MainPictureBox.Cursor = System.Windows.Forms.Cursors.Default;
        }



        #endregion

        #region MainMenu events
        /// <summary>
        /// Вызов меню настроек графического редактора
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSettings_Click(object sender, EventArgs e)
        {
            var f = new GraphicsControlSettingsForm();
            f.ShowDialog();
            _blueprint.Update(_storage);
            MainPictureBox.BackColor = _settings.BackgroundColor;
        }
        private void solidWorksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sldWorksObject = new SolidworksInteraction.SldWorksInteraction();
            if (sldWorksObject.Connect())
            {
                sldWorksObject.SetActiveDocument();
                sldWorksObject.ImportGrid(_blueprint.Background.Grid);
                sldWorksObject.ImportAxis(_blueprint.Background.Axis);
                sldWorksObject.ImportCollectionToActiveDoc(_storage.Objects, _blueprint.Settings.DrawSettings);
            }
            else
            {
                MessageBox.Show(@"Не удалось подключиться к SolidWorks");
            }
        }
        #endregion

        #region ObjectsPropertMenu events
        #region Names position
        private void buttonNameMenuTopLeftMenuItem_Click(object sender, EventArgs e)
        {
            NamesGenerator.Position = NamePosition.TopLeft;
            buttonNameMenu.Text = buttonNameMenuTopLeft.Text;
        }
        private void buttonNameMenuTopRightMenuItem_Click(object sender, EventArgs e)
        {
            NamesGenerator.Position = NamePosition.TopRight;
            buttonNameMenu.Text = buttonNameMenuTopRight.Text;
        }
        private void buttonNameMenuBottomLeftMenuItem_Click(object sender, EventArgs e)
        {
            NamesGenerator.Position = NamePosition.BottomLeft;
            buttonNameMenu.Text = buttonNameMenuBottomLeft.Text;
        }
        private void buttonNameMenuBottomRightMenuItem_Click(object sender, EventArgs e)
        {
            NamesGenerator.Position = NamePosition.BottomRight;
            buttonNameMenu.Text = buttonNameMenuBottomRight.Text;
        }
        #endregion
        #region PlaneType select
        private void buttonPlaneType3Points_Click(object sender, EventArgs e)
        {
            var o = (ICreatePlanes)SetObject;
            o.SetBuildType(PlaneCreateType.ThreePoints);
            buttonPlaneTypeMenu.Text = buttonPlaneType3Points.Text;
        }
        private void buttonPlaneTypeLinePoint_Click(object sender, EventArgs e)
        {
            var o = (ICreatePlanes)SetObject;
            o.SetBuildType(PlaneCreateType.LineAndPoint);
            buttonPlaneTypeMenu.Text = buttonPlaneTypeLinePoint.Text;
        }
        private void buttonPlaneTypeParrLine_Click(object sender, EventArgs e)
        {
            var o = (ICreatePlanes)SetObject;
            o.SetBuildType(PlaneCreateType.ParallelLines);
            buttonPlaneTypeMenu.Text = buttonPlaneTypeParallelLine.Text;
        }
        private void buttonPlaneTypeCrossedLine_Click(object sender, EventArgs e)
        {
            var o = (ICreatePlanes)SetObject;
            o.SetBuildType(PlaneCreateType.CrossedLines);
            buttonPlaneTypeMenu.Text = buttonPlaneTypeCrossedLine.Text;
        }
        private void buttonPlaneTypeSegmentPoint_Click(object sender, EventArgs e)
        {
            var o = (ICreatePlanes)SetObject;
            o.SetBuildType(PlaneCreateType.SegmentAndPoint);
            buttonPlaneTypeMenu.Text = buttonPlaneTypeSegmentPoint.Text;
        }

        private void buttonPlaneTypeParallelSegment_Click(object sender, EventArgs e)
        {
            var o = (ICreatePlanes)SetObject;
            o.SetBuildType(PlaneCreateType.ParallelSegments);
            buttonPlaneTypeMenu.Text = buttonPlaneTypeParallelSegment.Text;
        }

        private void buttonPlaneTypeCrossedSegment_Click(object sender, EventArgs e)
        {
            var o = (ICreatePlanes)SetObject;
            o.SetBuildType(PlaneCreateType.CrossedSegments);
            buttonPlaneTypeMenu.Text = buttonPlaneTypeCrossedSegment.Text;
        }
        #endregion

        #endregion

        private void доступностьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new TaskSettingsForm { Owner = Form.ActiveForm };
            f.ShowDialog();
            _blueprint.Update(_storage);
        }
    }
}

