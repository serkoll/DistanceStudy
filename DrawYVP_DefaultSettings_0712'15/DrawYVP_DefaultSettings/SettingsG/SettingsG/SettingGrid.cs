using System;
using System.Windows.Forms;

namespace SettingsG
{
    public partial class SettingGrid : UserControl
    {
        public SettingGrid()
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
