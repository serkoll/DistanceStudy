﻿using System;

namespace GraphicsModule.Configuration.Access.Structures
{
    [Serializable]
    public class GeneralAccess
    {
        public GeneralAccess()
        {
            IsAxisOXEnabled = IsAxisOYEnabled = IsAxisOZEnabled = IsBindToGridEnabled = IsGridEnabled = IsLinkLinesEnabled = true;
        }
        public GeneralAccess(bool isAxisOXEnabled, bool isAxisOYEnabled, bool isAxisOZEnabled, bool isGridEnabled, bool isLinkLinesEnabled,
            bool isBindToGridEnabled)
        {
            IsAxisOXEnabled = isAxisOXEnabled;
            IsAxisOYEnabled = isAxisOYEnabled;
            IsAxisOZEnabled = isAxisOZEnabled;
            IsGridEnabled = isGridEnabled;
            IsLinkLinesEnabled = isLinkLinesEnabled;
            IsBindToGridEnabled = isBindToGridEnabled;
        }
        public bool IsAxisOXEnabled { get; set; }
        public bool IsAxisOYEnabled { get; set; }
        public bool IsAxisOZEnabled { get; set; }
        public bool IsGridEnabled { get; set; }
        public bool IsLinkLinesEnabled { get; set; }
        public bool IsBindToGridEnabled { get; set; }
    }
}
