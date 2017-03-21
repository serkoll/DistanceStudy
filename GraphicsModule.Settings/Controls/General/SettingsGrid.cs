using System;
using System.Globalization;
using System.Windows.Forms;
using GraphicsModule.Settings.Forms;

namespace GraphicsModule.Settings.Controls.General
{
    public partial class SettingsGrid : UserControl
    {
        public GridS GridS { get; set; }
        public SettingsGrid()
        {
            InitializeComponent();
            GridS = GraphicsControlSettingsForm.ValueS.GridS;
            CheckBoxFlagDrawGrid.Checked = GridS.IsDraw;
            NumericUpDownPointsSize.Value = GridS.PointsSize;
            colorEdge.BackColor = GridS.PointsColor;
            gridStepOfWidth.Text = GridS.StepOfWidth.ToString();
            gridStepOfHeight.Text = GridS.StepOfHeight.ToString();
        }
        private void colorEdge_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                colorEdge.BackColor = colorDialog1.Color;
                GridS.PointsColor = colorDialog1.Color;
            }
        }

        private void CheckBox1_FlagDrawGrid_CheckedChanged(object sender, EventArgs e)
        {
            GridS.IsDraw = CheckBoxFlagDrawGrid.Checked;
        }

        private void NumericUpDown2_PointsWidth_ValueChanged(object sender, EventArgs e)
        {
            GridS.PointsSize = Convert.ToInt32(NumericUpDownPointsSize.Value.ToString(CultureInfo.InvariantCulture));
        }

        private void gridStep1Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridS.StepOfWidth = Convert.ToInt32(gridStepOfWidth.SelectedItem.ToString());
        }

        private void gridStepOfHeight_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridS.StepOfHeight = Convert.ToInt32(gridStepOfHeight.SelectedItem.ToString());
        }
    }
}
