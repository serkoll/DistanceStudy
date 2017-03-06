using System;
using GraphicsModule.Enums;
using GraphicsModule.Geometry;
using GraphicsModule.Interfaces;
using GraphicsModule.Settings;

namespace GraphicsModule
{
    public class NamesGenerator : INamesGenerator
    {
        public NamePosition Position { get; set; }
        private readonly DrawS _textSettings;
        private int _counter;
        private int _quality;
        public NamesGenerator(bool type, NamePosition startPosition, Settings.Settings textSettings)
        {
            _counter = type ? 65 : 49;
            _quality = 1;
            Position = startPosition;
            _textSettings = textSettings.DrawS;
        }
        public Name Generate()
        {
            var name = "";
            for (int i = 0; i < _quality; i++)
            {
                name += Convert.ToChar(_counter).ToString();
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
                case NamePosition.TopLeft:
                    {
                        delta[0] = -(_textSettings.TextFont.Size * _quality + 5);
                        delta[1] = -(_textSettings.TextFont.Height + 5);
                        break;
                    }
                case NamePosition.TopRight:
                    {
                        delta[0] = 5;
                        delta[1] = -(_textSettings.TextFont.Height + 5);
                        break;
                    }
                case NamePosition.BottomLeft:
                    {
                        delta[0] = -(_textSettings.TextFont.Size * _quality + 5);
                        delta[1] = 5;
                        break;
                    }
                case NamePosition.BottomRight:
                    {
                        delta[0] = 5;
                        delta[1] = 5;
                        break;
                    }
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return delta;
        }
    }
}
