using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Point 
{
    private float x;
    private float y;

    public Point(float x, float y) : this()
    {
        X = x;
        Y = y;
    }

    public float X { get => x; set => x = value; }
    public float Y { get => y; set => y = value; }

}
