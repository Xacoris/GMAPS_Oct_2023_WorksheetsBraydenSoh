using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    public static float FindDistance(HVector2D p1, HVector2D p2)
    {
        //Returns the distance between the first and second vector inputs.
        return (p2 - p1).Magnitude();
    }
}

