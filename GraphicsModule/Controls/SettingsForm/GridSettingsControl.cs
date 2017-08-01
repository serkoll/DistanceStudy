using System;
using System.Globalization;
using System.Windows.Forms;
using GraphicsModule.Configuration;
using GraphicsModule.Forms;

namespace GraphicsModule.Controls.SettingsForm
{
    public partial class GridSettingsControl : UserControl
    {
        public GridSettings GridSettings { get; set; }
        public GridSettingsControl()
        {
            InitializeComponent();
            GridSettings = GraphicsControlSettingsForm.CurrentSettings.Grid;
            CheckBoxFlagDrawGrid.Checked = GridSettings.IsDraw;
            NumericUpDownPointsSize.Value = GridSettings.PointsSize;
            colorEdge.BackColor = GridSettings.PointsColor;
            gridStepOfWidth.Text = GridSettings.StepOfWidth.ToString();
            gridStepOfHeight.Text = GridSettings.StepOfHeight.ToString();
        }
        private void colorEdge_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                colorEdge.BackColor = colorDialog1.Color;
                GridSettings.PointsColor = colorDialog1.Color;
            }
        }

        private void CheckBox1_FlagDrawGrid_CheckedChanged(object sender, EventArgs e)
        {
            GridSettings.IsDraw = CheckBoxFlagDrawGrid.Checked;
        }

        private void NumericUpDown2_PointsWidth_ValueChanged(object sender, EventArgs e)
        {
            GridSettings.PointsSize = Convert.ToInt32(NumericUpDownPointsSize.Value.ToString(CultureInfo.InvariantCulture));
        }

        private void gridStep1Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridSettings.StepOfWidth = Convert.ToInt32(gridStepOfWidth.SelectedItem.ToString());
        }

        private void gridStepOfHeight_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridSettings.StepOfHeight = Convert.ToInt32(gridStepOfHeight.SelectedItem.ToString());
        }
    }
}
