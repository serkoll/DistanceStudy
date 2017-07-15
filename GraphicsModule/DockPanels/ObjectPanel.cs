using System;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace GraphicsModule.DockPanels
{
    public partial class ObjectPanel : DockContent
    {
        public ObjectPanel()
        {
            InitializeComponent();
            this.DockStateChanged += ObjectPanel_DockStateChanged;      
        }

        private void ObjectPanel_DockStateChanged(object sender, EventArgs e)
        {
            if (this.DockState == DockState.DockLeft || this.DockState == DockState.DockLeftAutoHide || this.DockState == DockState.DockRight || this.DockState == DockState.DockRightAutoHide)
            {
                this.ObjectsBuildMenu.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            }
            else
            {
                this.ObjectsBuildMenu.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            }
        }
        
        
    }
}
