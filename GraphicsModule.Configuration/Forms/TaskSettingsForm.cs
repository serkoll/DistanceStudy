using System.Windows.Forms;
using GraphicsModule.Configuration.Controls.Tasks;

namespace GraphicsModule.Configuration.Forms
{
    public partial class TaskSettingsForm : Form
    {
        private readonly GeneralAccess _generalAccess = new GeneralAccess();
        private readonly LinesAccess _linesAccess = new LinesAccess();
        private readonly PlanesAccess _planesAccess = new PlanesAccess();
        private readonly PointsAccess _pointsAccess = new PointsAccess();
        private readonly SegmentsAccess _segmentsAccess = new SegmentsAccess();
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
                    groupBoxControls.Controls.Add(_generalAccess);
                    _generalAccess.Dock = DockStyle.Fill;
                    titleLabel.Text = @"Общий доступ";
                    break;
                case "Точка":
                    groupBoxControls.Controls.Clear();
                    groupBoxControls.Controls.Add(_linesAccess);
                    _linesAccess.Dock = DockStyle.Fill;
                    titleLabel.Text = @"Доступ точек";
                    break;
                case "Прямая":
                    groupBoxControls.Controls.Clear();
                    groupBoxControls.Controls.Add(_planesAccess);
                    _planesAccess.Dock = DockStyle.Fill;
                    titleLabel.Text = @"Доступ прямых";
                    break;
                case "Отрезок":
                    groupBoxControls.Controls.Clear();
                    groupBoxControls.Controls.Add(_pointsAccess);
                    _pointsAccess.Dock = DockStyle.Fill;
                    titleLabel.Text = @"Доступ отрезков";
                    break;
                case "Плоскость":
                    groupBoxControls.Controls.Clear();
                    groupBoxControls.Controls.Add(_segmentsAccess);
                    _segmentsAccess.Dock = DockStyle.Fill;
                    titleLabel.Text = @"Доступ плоскости";
                    break;
            }
        }
    }
}
