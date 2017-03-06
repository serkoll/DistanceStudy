﻿using System.Drawing;
using GraphicsModule.Settings;

namespace GraphicsModule.Geometry.Interfaces
{
    public interface ILineOfPlane : IObject
    {
        void DrawLineOnly(DrawS st, Point framecenter, Graphics g);
    }
}
