using System.Collections.ObjectModel;
using GraphicsModule.Controls;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Geometry.Objects;

namespace GraphicsModule.Form
{
    public partial class FormGraphicsControl : System.Windows.Forms.Form
    {
        public FormGraphicsControl()
        {
            InitializeComponent();
            KeyPreview = true;
        }
        public Collection<IObject> Export()
        {
            return graphicsControl1.ExportObjects();
        }
        public void Import(Collection<IObject> obj)
        {
            graphicsControl1.ImportObjects(obj);
        }

        public Collection<IObject> ExportSelected()
        {
            return graphicsControl1.ExportSelected();
        }

        private void FormGraphicsControl_Load(object sender, System.EventArgs e)
        {
            graphicsControl1.Focus();
            GraphicsControl.StaticName = graphicsControl1.Name;
        }
    }
}
