using System.IO;
using System.Windows.Forms;
using GraphicsModule.Settings.Controls;

namespace GraphicsModule.Settings.Forms
{
    public partial class FormSettings : Form
    {
        private readonly SettingsAxis _stAxis = new SettingsAxis();
        private readonly SettingsGrid _stGrid = new SettingsGrid();
        private readonly SettingsLine _stLine = new SettingsLine();
        private readonly SettingsBackground _stBackground = new SettingsBackground();
        private readonly SettingsCursor _stCursor = new SettingsCursor();
        private readonly SettingsLink _stLink = new SettingsLink();
        private readonly SettingsPoint _stPoint = new SettingsPoint();
        private readonly SettingsSegment _stSegment = new SettingsSegment();
        private readonly string fName = "config.cfg";
        public static Settings ValueS;
        public FormSettings()
        {
            InitializeComponent();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            switch (e.Node.Text)
            {
                case "Прямая":
                    groupBoxControls.Controls.Clear();
                    groupBoxControls.Controls.Add(_stLine);
                    _stLine.Dock = DockStyle.Fill;
                    labelTitle.Text = @"Настройка прямой";
                    break;
                case "Фон":
                    groupBoxControls.Controls.Clear();
                    groupBoxControls.Controls.Add(_stBackground);
                    _stBackground.Dock = DockStyle.Fill;
                    labelTitle.Text = @"Настройка фона";
                    break;
                case "Курсор":
                    groupBoxControls.Controls.Clear();
                    groupBoxControls.Controls.Add(_stCursor);
                    _stCursor.Dock = DockStyle.Fill;
                    labelTitle.Text = @"Стиль курсоров";
                    break;
                case "Сетка":
                    groupBoxControls.Controls.Clear();
                    groupBoxControls.Controls.Add(_stGrid);
                    _stGrid.Dock = DockStyle.Fill;
                    labelTitle.Text = @"Настройка сетки";
                    break;
                case "Оси":
                    groupBoxControls.Controls.Clear();
                    groupBoxControls.Controls.Add(_stAxis);
                    _stAxis.Dock = DockStyle.Fill;
                    labelTitle.Text = @"Настройка осей";
                    break;
                case "Точка":
                    groupBoxControls.Controls.Clear();
                    groupBoxControls.Controls.Add(_stPoint);
                    _stPoint.Dock = DockStyle.Fill;
                    labelTitle.Text = @"Настройки точки";
                    break;
                case "Линии связи":
                    groupBoxControls.Controls.Clear();
                    groupBoxControls.Controls.Add(_stLink);
                    _stLink.Dock = DockStyle.Fill;
                    labelTitle.Text = @"Настройки линий связи";
                    break;
                case "Отрезок":
                    groupBoxControls.Controls.Clear();
                    groupBoxControls.Controls.Add(_stSegment);
                    _stSegment.Dock = DockStyle.Fill;
                    labelTitle.Text = @"Настройки отрезка";
                    break;
            }
        }

        private void buttonOK_Click(object sender, System.EventArgs e)
        {
            ValueS.AxisS = _stAxis.AxisS;
            Close();
        }
        private void buttonCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
