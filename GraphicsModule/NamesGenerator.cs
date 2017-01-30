using System;
using GraphicsModule.Geometry;
using GraphicsModule.Geometry.Interfaces;
using GraphicsModule.Interfaces;
using GraphicsModule.Settings;

namespace GraphicsModule
{
    public class NamesGenerator : INamesGenerator
    {
        public byte Position { get; set; }
        private readonly DrawS _textSettings;
        private int _counter;
        private int _quality;
        public NamesGenerator(bool type, byte startPosition, Settings.Settings textSettings)
        {
            _counter = type ? 65 : 49;
            _quality = 1;
            Position = startPosition;
            _textSettings = textSettings.DrawS;
        }
        public Name Generate(IObject obj)
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
            var delta = GetDeltaFromPosition();
            if (_counter < 90) _counter++;
            else
            {
                _counter = 65;
                _quality++;
            }
            return new Name(name, delta[0], delta[1]);
        }
        private float[] GetDeltaFromPosition()
        {
            var delta = new float[2];
            switch (Position)
            {
                case 0:
                    {
                        delta[0] = -(_textSettings.TextFont.Size * _quality + 5);
                        delta[1] = -(_textSettings.TextFont.Height + 5);
                        break;
                    }
                case 1:
                    {
                        delta[0] = 5;
                        delta[1] = -(_textSettings.TextFont.Height + 5);
                        break;
                    }
                case 2:
                    {
                        delta[0] = -(_textSettings.TextFont.Size * _quality + 5);
                        delta[1] = 5;
                        break;
                    }
                case 3:
                    {
                        delta[0] = 5;
                        delta[1] = 5;
                        break;
                    }
            }
            return delta;
        }
    }
}
