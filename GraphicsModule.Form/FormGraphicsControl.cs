using System.Collections.ObjectModel;
using GraphicsModule.Geometry.Objects;

namespace GraphicsModule.Form
{
    public partial class FormGraphicsControl : System.Windows.Forms.Form
    {
        public FormGraphicsControl()
        {
            InitializeComponent();
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
    }
}
