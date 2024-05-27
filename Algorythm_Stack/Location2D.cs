using System;


public class Location2D
{
    public int X { get; set; }
    public int Y { get; set; }

    public Location2D(int row = 0, int column = 0)
    {
        X = row;
        Y = column;
    }
}

