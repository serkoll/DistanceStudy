using System;
using System.Windows.Forms;

namespace GraphicsModule.Settings.Controls
{
    public partial class SettingsGrid : UserControl
    {
        public SettingsGrid()
        {
            InitializeComponent();
        }

        private void colorEdge_Paint(object sender, PaintEventArgs e)
        {
        }

        private void colorEdge_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                colorEdge.BackColor = colorDialog1.Color;
        }

    }
}
