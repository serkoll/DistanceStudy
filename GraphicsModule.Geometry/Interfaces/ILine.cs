using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicsModule.Geometry.Structures;

namespace GraphicsModule.Geometry.Interfaces
{
    public interface ILine : IObject
    {
        LineCoefficients Coefficients { get; }
    }
}
