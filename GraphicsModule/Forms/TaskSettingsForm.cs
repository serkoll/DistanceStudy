using System.Linq;
using System.Windows.Forms;
using GraphicsModule.Configuration.Access;
using GraphicsModule.Controls;
using GraphicsModule.Controls.TaskAccess;

namespace GraphicsModule.Forms
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
                    groupBoxControls.Controls.Add(_pointsAccessControl);
                    _pointsAccessControl.Dock = DockStyle.Fill;
                    titleLabel.Text = @"Доступ точек";
                    break;
                case "Прямая":
                    groupBoxControls.Controls.Clear();
                    groupBoxControls.Controls.Add(_linesAccessControl);
                    _linesAccessControl.Dock = DockStyle.Fill;
                    titleLabel.Text = @"Доступ прямых";
                    break;
                case "Отрезок":
                    groupBoxControls.Controls.Clear();
                    groupBoxControls.Controls.Add(_segmentsAccessControl);
                    _segmentsAccessControl.Dock = DockStyle.Fill;
                    titleLabel.Text = @"Доступ отрезков";
                    break;
                case "Плоскость":
                    groupBoxControls.Controls.Clear();
                    groupBoxControls.Controls.Add(_planesAccessControl);
                    _planesAccessControl.Dock = DockStyle.Fill;
                    titleLabel.Text = @"Доступ плоскости";
                    break;
            }
        }
        private void button1_Click(object sender, System.EventArgs e)
        {
            GraphicsControlSettingsForm.CurrentSettings.PrimitivesAcces = new PrimitivesAccess(
                _generalAccessControl.GeneralAccess, 
                _pointsAccessControl.PointsAccess, 
                _linesAccessControl.LinesAccess, 
                _segmentsAccessControl.SegmentsAccess, 
                _planesAccessControl.PlanesAccess);
            var graphicsControl = Owner.Controls.Find(GraphicsControl.StaticName, false).First() as GraphicsControl;
            graphicsControl?.SetAccess();
            Close();
        }
    }
}
