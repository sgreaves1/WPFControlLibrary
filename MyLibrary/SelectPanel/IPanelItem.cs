﻿namespace MyLibrary.SelectPanel
{
    public interface IPanelItem
    {
        string Name { get; set; }

        bool IsSelected { get; set; }
    }
}
