using System;
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
        public string Generate()
        {
            var name = "";
            for (int i = 0; i < _quality; i++)
            {
                name += Convert.ToChar(_counter).ToString();
            }
            if(_counter < 90) _counter++;
            else
            {
                _counter = 65;
                _quality++;
            }
            return name;
        }
    }
}
