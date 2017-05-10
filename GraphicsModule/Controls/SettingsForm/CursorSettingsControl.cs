using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GraphicsModule.Configuration.Cursors;

namespace GraphicsModule.Controls.SettingsForm
{
    public partial class CursorSettingsControl : UserControl
    {
        private readonly List<Button> _buttons;
        internal readonly List<ColorDialog> ColorDialogs;
        internal readonly List<Configuration.Cursors.Cursor> Cursors;
        public List<PictureBox> CursorBoxes;
        public List<PictureBox> ColorBase; 

        public CursorSettingsControl()
        {
            InitializeComponent();
            ColorBase = new List<PictureBox>
            {
                pictureBox1,
                pictureBox2,
                pictureBox3,
                pictureBox4,
                pictureBox5,
                pictureBox6,
                pictureBox7
            };
            _buttons = new List<Button> { addOnButton, crossButton, starButton, circleButton, envelopeButton, triangleButton, squareButton };
            ColorDialogs = new List<ColorDialog> { addOnColor, crossColor, starColor, circleColor, envelopeColor, triangleColor, squareColor };
            Cursors = new List<Configuration.Cursors.Cursor> { new AddOnPoint(), new Cross(), new Star(), new Circle(), new Envelope(), new Triangle(), new Square() };
            CursorBoxes = new List<PictureBox> { addOnBox, crossBox, starBox, circleBox, envelopeBox, triangleBox, squareBox };
            foreach (var cursorBox in CursorBoxes)
            {
                cursorBox.Refresh();
            }
        }

        private void cursorButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;

            for (int i = 0; i < _buttons.Count; i++)
            {
                if (button != null && button.Name == _buttons[i].Name)
                {
                    if (ColorDialogs[i].ShowDialog() == DialogResult.OK)
                    {
                        var bitmap = new Bitmap(CursorBoxes[i].Width,CursorBoxes[i].Height);
                        ColorBase[i].BackColor = ColorDialogs[i].Color;
                        Cursors[i].Draw(CursorBoxes[i].Width, CursorBoxes[i].Height, ColorBase[i].BackColor, Graphics.FromImage(bitmap));
                        CursorBoxes[i].Image = bitmap;
                    }
                }
            }
        }
    }
}
