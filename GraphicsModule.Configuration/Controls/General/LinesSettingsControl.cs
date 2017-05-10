using System.Windows.Forms;

namespace GraphicsModule.Configuration.Controls
{
    public partial class LinesSettingsControl : UserControl
    {
        public LinesSettingsControl()
        {
            InitializeComponent();
        }

        private void nameLine1stPlaneBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (nameLine1stPlaneBox.SelectedIndex == nameLine1stPlaneBox.Items.IndexOf(nameLine1stPlaneBox.SelectedItem))
            {
                nameLine2ndPlaneBox.SelectedIndex = nameLine1stPlaneBox.SelectedIndex;
                nameLine3rdPlaneBox.SelectedIndex = nameLine1stPlaneBox.SelectedIndex;
            }
        }

        private void nameLine2ndPlaneBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (nameLine2ndPlaneBox.SelectedIndex == nameLine2ndPlaneBox.Items.IndexOf(nameLine2ndPlaneBox.SelectedItem))
            {
                nameLine1stPlaneBox.SelectedIndex = nameLine2ndPlaneBox.SelectedIndex;
                nameLine3rdPlaneBox.SelectedIndex = nameLine2ndPlaneBox.SelectedIndex;
            }
        }

        private void nameLine3rdPlaneBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (nameLine3rdPlaneBox.SelectedIndex == nameLine3rdPlaneBox.Items.IndexOf(nameLine3rdPlaneBox.SelectedItem))
            {
                nameLine1stPlaneBox.SelectedIndex = nameLine3rdPlaneBox.SelectedIndex;
                nameLine2ndPlaneBox.SelectedIndex = nameLine3rdPlaneBox.SelectedIndex;
            }
        }
    }
}
