using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SettingsG.Cursors
{
    class Circle:Cursor
    {
        public override void Draw(int x, int y, Color color, Graphics picture)
        {
            Graphics g = picture;
            g.DrawEllipse(new Pen(color), 3*x/8,3*y/8,10,10);
        }
    }
}
