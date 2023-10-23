using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//[Serializable]
public class HVector2D
{
    public float x, y;
    public float h;

    public HVector2D(float _x, float _y)
    {
        x = _x;
        y = _y;
        h = 1.0f;
    }

    public HVector2D(Vector2 _vec)
    {
        x = _vec.x;
        y = _vec.y;
        h = 1.0f;
    }

    public HVector2D()
    {
        x = 0;
        y = 0;
        h = 1.0f;
    }

    public static HVector2D operator +(HVector2D a, HVector2D b)
    {
        return new HVector2D(a.x + b.x, a.y + b.y);
    }

    public static HVector2D operator -(HVector2D a, HVector2D b)
    {
        return new HVector2D(a.x - b.x, a.y - b.y);
    }

    public static HVector2D operator *(HVector2D a, float scalar)
    {
        return new HVector2D(a.x * scalar, a.y * scalar);
    }

    public static HVector2D operator /(HVector2D a, float scalar)
    {
        return new HVector2D(a.x / scalar, a.y / scalar);
    }

    public float Magnitude()
    {
        return (float)Math.Sqrt(x * x + y * y);
    }

    public void Normalize()
    {
        float mag = Magnitude();
        x/= mag;
        y/= mag;

    }

     public float DotProduct(HVector2D a)
     {
        return (a.x * x + a.y * y);
     }

     public HVector2D Projection(HVector2D a)
     {
        HVector2D b = a * 1;
        b.Normalize();

        return (a * (DotProduct(b) / a.Magnitude()));
     }

     public float FindAngle(HVector2D a)
     {
        return (float)Math.Acos(DotProduct(a) / (Magnitude() * a.Magnitude()));
     }

    public Vector2 ToUnityVector2()
    {
        return new Vector3(x, y); // change this
    }

    public Vector3 ToUnityVector3()
    {
        return new Vector3(x, y, 0); // change this
    }

    // public void Print()
    // {

    // }
}
