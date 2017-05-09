using System.Windows.Forms;
using GraphicsModule.Configuration;
using GraphicsModule.Controls.SettingsForm;

namespace GraphicsModule.Forms
{
    public partial class GraphicsControlSettingsForm : Form
    {
        private readonly AxisSettingsControl _stAxis = new AxisSettingsControl();
        private readonly GridSettingsControl _stGrid = new GridSettingsControl();
        private readonly LinesSettingsControl _stLine = new LinesSettingsControl();
        private readonly BackgroundSettingsControl _stBackground = new BackgroundSettingsControl();
        private readonly CursorSettingsControl _stCursor = new CursorSettingsControl();
        private readonly LinkLineSettingsControl _stLink = new LinkLineSettingsControl();
        private readonly PointsSettingsControl _stPoint = new PointsSettingsControl();
        private readonly SegmentsSettingsControl _stSegment = new SegmentsSettingsControl();
        private const string FileName = "config.cfg";
        public static Settings CurrentSettings;
        public GraphicsControlSettingsForm()
        {
            InitializeComponent();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            switch (e.Node.Text) 
            {
                case "Общие":
                    labelTitle.Text = @"Общие настройки";
                    break;
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
            CurrentSettings.BackgroundColor = _stBackground.BackgroundColor;
            CurrentSettings.Serialize(FileName);
            Close();
        }
        private void buttonCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
