using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Forms;
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
        public IList<IObject> Export()
        {
            return graphicsControl1.ExportObjects();
        }
        public void Import(IList<IObject> obj)
        {
            graphicsControl1.ImportObjects(obj);
        }

        public IList<IObject> ExportSelected()
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
