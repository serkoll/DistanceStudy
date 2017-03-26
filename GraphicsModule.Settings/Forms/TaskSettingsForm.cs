using System.Windows.Forms;
using GraphicsModule.Configuration.Controls.Tasks;

namespace GraphicsModule.Configuration.Forms
{
    public partial class TaskSettingsForm : Form
    {
        private readonly GeneralAccessControl _generalAccessControl = new GeneralAccessControl();
        private readonly LinesAccessControl _linesAccessControl = new LinesAccessControl();
        private readonly PlanesAccessControl _planesAccessControl = new PlanesAccessControl();
        private readonly PointsAccessControl _pointsAccessControl = new PointsAccessControl();
        private readonly SegmentsAccessControl _segmentsAccessControl = new SegmentsAccessControl();
        public TaskSettingsForm()
        {
            InitializeComponent();
        }

        private void mainTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            switch (e.Node.Text)
            {
                case "Общие":
                    groupBoxControls.Controls.Clear();
                    groupBoxControls.Controls.Add(_generalAccessControl);
                    _generalAccessControl.Dock = DockStyle.Fill;
                    titleLabel.Text = @"Общий доступ";
                    break;
                case "Точка":
                    groupBoxControls.Controls.Clear();
                    groupBoxControls.Controls.Add(_linesAccessControl);
                    _linesAccessControl.Dock = DockStyle.Fill;
                    titleLabel.Text = @"Доступ точек";
                    break;
                case "Прямая":
                    groupBoxControls.Controls.Clear();
                    groupBoxControls.Controls.Add(_planesAccessControl);
                    _planesAccessControl.Dock = DockStyle.Fill;
                    titleLabel.Text = @"Доступ прямых";
                    break;
                case "Отрезок":
                    groupBoxControls.Controls.Clear();
                    groupBoxControls.Controls.Add(_pointsAccessControl);
                    _pointsAccessControl.Dock = DockStyle.Fill;
                    titleLabel.Text = @"Доступ отрезков";
                    break;
                case "Плоскость":
                    groupBoxControls.Controls.Clear();
                    groupBoxControls.Controls.Add(_segmentsAccessControl);
                    _segmentsAccessControl.Dock = DockStyle.Fill;
                    titleLabel.Text = @"Доступ плоскости";
                    break;
            }
        }
    }
}
