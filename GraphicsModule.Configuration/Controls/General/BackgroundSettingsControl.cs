﻿using System;
using System.Drawing;
using System.Windows.Forms;
using GraphicsModule.Configuration.Forms;

namespace GraphicsModule.Configuration.Controls
{
    public partial class BackgroundSettingsControl : UserControl
    {
        public Color BackgroundColor { get; set; }
        public BackgroundSettingsControl()
        {

            InitializeComponent();
            BackgroundColor = ConfigurationForm.ValueS.BackgroundColor;
            pictureBox1.BackColor = BackgroundColor;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.BackColor = colorDialog1.Color;
                BackgroundColor = colorDialog1.Color;
            }
        }
    }
}
