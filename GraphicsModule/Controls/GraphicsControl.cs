using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GraphicsModule.Cursors;
using System.IO;
using GraphicsModule.Configuration;
using GraphicsModule.Enums;
using GraphicsModule.Forms;
using GraphicsModule.Geometry;
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

            GraphicsControl.NamesGenerator = new NamesGenerator(true, 0, _settings);
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
            _ptMenuSelector = new Menu.PointMenuSelector(MainPictureBox, buttonPointsMenu, ObjectsPropertyMenu, _settings.Access.Points);
            _lnMenuSelector = new Menu.LineMenuSelector(MainPictureBox, buttonLinesMenu, ObjectsPropertyMenu, _settings.Access.Lines);
            _sgMenuSelector = new Menu.SegmentMenuSelector(MainPictureBox, buttonSegmentMenu, ObjectsPropertyMenu, _settings.Access.Segments);
            _plMenuSelector = new Menu.PlaneMenuSelector(MainPictureBox, buttonPlanesMenu, ObjectsPropertyMenu, _settings.Access.Planes);
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
            this.buttonPointsMenu.Enabled = _settings.Access.Points.IsPointsEnabled;
            this.buttonLinesMenu.Enabled = _settings.Access.Lines.IsLinesEnabled;
            this.buttonSegmentMenu.Enabled = _settings.Access.Segments.IsSegmentsEnabled;
            this.buttonPlanesMenu.Enabled = _settings.Access.Planes.IsPlanesEnabled;
        }
        public void SetAccess()
        {
            this.buttonPointsMenu.Enabled = _settings.Access.Points.IsPointsEnabled;
            this.buttonLinesMenu.Enabled = _settings.Access.Lines.IsLinesEnabled;
            this.buttonSegmentMenu.Enabled = _settings.Access.Segments.IsSegmentsEnabled;
            this.buttonPlanesMenu.Enabled = _settings.Access.Planes.IsPlanesEnabled;
            _ptMenuSelector.SetAccess(_settings.Access.Points);
            _lnMenuSelector.SetAccess(_settings.Access.Lines);
            _plMenuSelector.SetAccess(_settings.Access.Planes);
            _sgMenuSelector.SetAccess(_settings.Access.Segments);
        }

        private void GraphicsControl_Load(object sender, EventArgs e)
        {
            _blueprint = new Blueprint(_settings, MainPictureBox);
        }

        //TODO: при переходе на несколько чертежей изменить
        private void GraphicsControl_Resize(object sender, EventArgs e)
        {
            if (_blueprint == null) return;
            _blueprint.CalculateBackground();
            _blueprint.Update();
        }

        #region Other operations
        /// <summary>
        /// Импорт графических объектов
        /// </summary>
        /// <param name="coll"></param>
        public void ImportObjects(IList<IObject> coll)
        {
            _blueprint = new Blueprint(_settings, new Storage(coll), MainPictureBox);
            _blueprint.Update();
        }

        //TODO: при новой логике с несколькими чертежами подумать по поводу переделки методов. Скорее всего перенести в панели
        /// <summary>
        /// Экспорт графических объектов
        /// </summary>
        /// <returns></returns>
        public IList<IObject> ExportObjects()
        {
            return _blueprint.Storage.Objects;
        }

        public IList<IObject> ExportSelected()
        {
            return _blueprint.Storage.SelectedObjects;
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
                _blueprint.Settings.Drawing.LinkLinesSettings.Enabled = true;
                _blueprint.Update();
            }
            else
            {
                labelStatusLinkLine.BorderStyle = Border3DStyle.RaisedInner;
                _blueprint.Settings.Drawing.LinkLinesSettings.Enabled = false;
                _blueprint.Update();
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
                _blueprint.Settings.Grid.IsDraw = true;
                _blueprint.Update();
            }
            else
            {
                labelStatusGrid.BorderStyle = Border3DStyle.RaisedInner;
                _blueprint.Settings.Grid.IsDraw = false;
                _blueprint.Update();
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
                _blueprint.Settings.Axis.IsDraw = true;
                _blueprint.Update();
            }
            else
            {
                labelSatusAxis.BorderStyle = Border3DStyle.RaisedInner;
                _blueprint.Settings.Axis.IsDraw = false;
                _blueprint.Update();
            }
        }

        #endregion

        #region Control and PictureBox events

        private void MainPictureBox_MouseDown(object sender, EventArgs e)
        {
            HideSelectorMenus();
            var mousecoords = MainPictureBox.PointToClient(MousePosition);  
            if (SetObject != null) 
            {
                SetObject.AddToStorageAndDraw(mousecoords, _blueprint); 
                //TODO: нужно ли
                _blueprint.Refresh(); 
            }
            if (Operations != null)
            {
                Operations.Execute(mousecoords, _blueprint); 
                _blueprint.Refresh(); 
            }
        }

        private void MainPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            _crMove.CursorPointToGridMove(_blueprint); // Привязка к сетке
            labelValueX.Text = (MainPictureBox.PointToClient(Cursor.Position).X - _blueprint.CoordinateSystemCenterPoint.X).ToString();
            labelValueY.Text = (MainPictureBox.PointToClient(Cursor.Position).Y - _blueprint.CoordinateSystemCenterPoint.Y).ToString();
        }

        private void GraphicsControl_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    {
                        _blueprint.Storage.TempObjects.Clear();
                        SetObject = null;
                        Operations = null;
                        _blueprint.Storage.SelectedObjects.Clear();
                        _blueprint.Update();
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
            _blueprint.Storage.ClearTempCollections();
            _blueprint.Update();
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
            _blueprint.Storage.ClearTempCollections();
            _blueprint.Update();
            _lnMenuSelector.Location = new Point(ObjectsBuildMenu.Size.Width, ObjectsBuildMenu.Location.Y + buttonPointsMenu.Size.Height);
            _lnMenuSelector.Visible = true;
            _lnMenuSelector.BringToFront();
        }
        private void buttonSegmentMenu_Click(object sender, EventArgs e)
        {
            HideSelectorMenus();
            _blueprint.Storage.ClearTempCollections();
            _blueprint.Update();
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
            _blueprint.Storage.ClearAllCollections();
            _blueprint.Update();
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
            new DeleteSelected().Execute(_blueprint);
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
            _blueprint.Update();
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
                sldWorksObject.ImportCollectionToActiveDoc(_blueprint.Storage.Objects, _blueprint.Settings.Drawing);
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
            _blueprint.Update();
        }
    }
}

