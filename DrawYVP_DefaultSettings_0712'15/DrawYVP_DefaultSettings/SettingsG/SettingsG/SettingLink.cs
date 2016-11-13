using System;
using System.Drawing;
using System.Windows.Forms;

namespace SettingsG
{
    public partial class SettingLink : UserControl
    {
        private readonly SettingsXml _xml;

        public SettingLink()
        {
            _xml = new SettingsXml();
            InitializeComponent();
        }
        private void link1ColorBox_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                link1ColorBox.BackColor = colorDialog1.Color;
            }
        }

        private void link2ColorBox_Click(object sender, EventArgs e)
        {
            if (colorDialog2.ShowDialog() == DialogResult.OK)
            {
                link2ColorBox.BackColor = colorDialog2.Color;
            }
        }

        private void link3ColorBox_Click(object sender, EventArgs e)
        {
            if (colorDialog3.ShowDialog() == DialogResult.OK)
            {
                link3ColorBox.BackColor = colorDialog3.Color;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                _xml._tag = "Axis";
                link1ColorBox.BackColor = ColorTranslator.FromWin32(int.Parse(_xml.GetElement(8, _xml._tag).Value));
                link2ColorBox.BackColor = ColorTranslator.FromWin32(int.Parse(_xml.GetElement(9, _xml._tag).Value));
                link3ColorBox.BackColor = ColorTranslator.FromWin32(int.Parse(_xml.GetElement(10, _xml._tag).Value));
            }
            else
            {
                _xml._tag = "Link";
                link1ColorBox.BackColor = ColorTranslator.FromWin32(int.Parse(_xml.GetElement(3, _xml._tag).Value));
                link2ColorBox.BackColor = ColorTranslator.FromWin32(int.Parse(_xml.GetElement(4, _xml._tag).Value));
                link3ColorBox.BackColor = ColorTranslator.FromWin32(int.Parse(_xml.GetElement(5, _xml._tag).Value));
            }
        }
    }
}
