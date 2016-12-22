using System;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Interfaces;

namespace GraphicsModule
{
    public class NamesGenerator : INamesGenerator
    {
        private int _counter;
        private int _quality;
        public NamesGenerator(bool type)
        {
            _counter = type ? 65 : 49;
            _quality = 1;
        }
        public string Generate(IObject obj)
        {
            var name = "";
            for (int i = 0; i < _quality; i++)
            {
                name += Convert.ToChar(_counter).ToString();
            }
            var type = obj.GetType().GetInterfaces();
            if (type.Length > 2)
            {
                if (type[2] == typeof(IObjectOfPlane1X0Y)) name += "'";
                else if (type[2] == typeof(IObjectOfPlane2X0Z)) name += "''";
                else name += "'''";
            }
            if (_counter < 90) _counter++;
            else
            {
                _counter = 65;
                _quality++;
            }
            return name;
        }
    }
}
