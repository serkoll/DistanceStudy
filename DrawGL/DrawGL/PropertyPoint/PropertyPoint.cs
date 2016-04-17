using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GeomObjects.Points;
using GeomObjects.Lines;
using GeomObjects.EquationsSysCalc;
using GeomObjects.Plans;

namespace DrawG
{
    /// <summary>
    /// Класс, содержащий свойства для задания и отрисовки точки
    /// </summary>
    static class PropertyPoint
    {
        public static Color Color_Point = Color.Black; //Цвет точки для отрисовки
        public static int Diametre_Point = 3; //Диаметр точки для отрисовки
    }
}
