﻿
namespace MyLibrary
{
    public interface IProgressBarListItem
    {
        string Name { get; set; }
        string ImageName { get; set; }
        int Value { get; set; }
    }
}
