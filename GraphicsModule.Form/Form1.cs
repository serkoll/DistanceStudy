using System.Collections.ObjectModel;
using GraphicsModule.Geometry.Objects;
using GraphicsModule.Geometry.Objects.Point;

namespace GraphicModule.Form
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
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
    }
}
