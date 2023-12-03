using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HMatrix2D
{
    public float[,] entries { get; set; } = new float[3, 3];

    public HMatrix2D()
    {
    // your code here
        
    }

    public HMatrix2D(float[,] multiArray)
    {
        for (int x = 0; x < 3; x++)     //row
        {
            for (int y = 0; y < 3; y++) //col
            {
                entries[x,y] = multiArray[x,y];
            }
        }
    }

    public HMatrix2D(float m00, float m01, float m02,
             float m10, float m11, float m12,
             float m20, float m21, float m22)
    {
        // First row 
        //First col
        entries[0, 0] = m00;

        //Second col
        entries[0, 1] = m01;

        //Third col
        entries[0, 2] = m02;

        // Second row 
        //First col
        entries[1, 0] = m10;

        //Second col
        entries[1, 1] = m11;

        //Third col
        entries[1, 2] = m12;

        //Third row
        //First col
        entries[2, 0] = m20;

        //Second col
        entries[2, 1] = m21;

        //Third col
        entries[2, 2] = m22;
    }

    public static HMatrix2D operator +(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D Check = new HMatrix2D();
        for (int x = 0; x < 3; x++)     //row
        {
            for (int y = 0; y < 3; y++) //col
            {
                //Adds the values from 2 matrices based on the same rows and columns. Only applies to matrices of same size.
                Check.entries[x,y] = (left.entries[x, y] + right.entries[x, y]);
            }
        }
        //returns the values after the calculation in the temporary matrix called Check.
        return Check;
            //return new HMatrix2D(left.entries[0, 0] + right.entries[0, 0], left.entries[0, 1] + right.entries[0, 1], left.entries[0, 2] + right.entries[0, 2],
            //left.entries[1, 0] + right.entries[1, 0], left.entries[1, 1] + right.entries[1, 1], left.entries[1, 2] + right.entries[1, 2],
            //left.entries[2, 0] + right.entries[2, 0], left.entries[2, 1] + right.entries[2, 1], left.entries[2, 2] + right.entries[2, 2]);
    }

    public static HMatrix2D operator -(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D Check = new HMatrix2D();
        for (int x = 0; x < 3; x++)     //row
        {
            for (int y = 0; y < 3; y++) //col
            {
                //Subtracts the values of right matrix from left matrix based on same row and column. Only applies to matrices of same size.
                Check.entries[x, y] = (left.entries[x, y] - right.entries[x, y]);
            }
        }
        //returns the values after the calculation in the temporary matrix called Check.
        return Check;
            //return new HMatrix2D(left.entries[0, 0] - right.entries[0, 0], left.entries[0, 1] - right.entries[0, 1], left.entries[0, 2] - right.entries[0, 2],
            //left.entries[1, 0] - right.entries[1, 0], left.entries[1, 1] - right.entries[1, 1], left.entries[1, 2] - right.entries[1, 2],
            //left.entries[2, 0] - right.entries[2, 0], left.entries[2, 1] - right.entries[2, 1], left.entries[2, 2] - right.entries[2, 2]);
    }

    public static HMatrix2D operator *(HMatrix2D left, float scalar)
    {
        HMatrix2D Check = new HMatrix2D();
        for (int x = 0; x < 3; x++)     //row
        {
            for (int y = 0; y < 3; y++) //col
            {
                //Scalar multiplication of matrix where all the individual values for the rows and columns multiply by the same value.
                Check.entries[x, y] = (left.entries[x, y] * scalar);
            }
        }
        //returns the values after the calculation in the temporary matrix called Check.
        return Check;
        //return new HMatrix2D(left.entries[0, 0] * scalar, left.entries[0, 1] * scalar, left.entries[0, 2] * scalar,
            //left.entries[1, 0] * scalar, left.entries[1, 1] * scalar, left.entries[1, 2] * scalar,
            //left.entries[2, 0] * scalar, left.entries[2, 1] * scalar, left.entries[2, 2] * scalar);
    }

    // Note that the second argument is a HVector2D object
    //
    public static HVector2D operator *(HMatrix2D left, HVector2D right)
    {
        //returns a HVector2D variable whereby a matrix of size 3x3 multiplies by the HVector Matrix of 3x1.
        // in this case, right.h is just a value of 1 and is just used to allow for matrix multiplication.
        return new HVector2D(
            left.entries[0, 0] * right.x + left.entries[0, 1] * right.y + left.entries[0, 2] * right.h,
            left.entries[1, 0] * right.x + left.entries[1, 1] * right.y + left.entries[1, 2] * right.h
            );
    }

    // Note that the second argument is a HMatrix2D object
    //
    public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right)
    {
    return new HMatrix2D
    (
    /* 
        00 01 02    00 xx xx
        xx xx xx    10 xx xx
        xx xx xx    20 xx xx
        */

    //As this is a matrix by matrix multiplication, the col size of the left matrix must match the row size of the right matrix.

    //Here, we have the first row of the left matrix multiplied by the first column of the right matrix.
    //Once we get the values from each multiplication, we add them together to form the first row first column value for the result matrix.
    left.entries[0, 0] * right.entries[0, 0] + left.entries[0, 1] * right.entries[1, 0] + left.entries[0, 2] * right.entries[2, 0],

    /* 
        00 01 02    xx 01 xx
        xx xx xx    xx 11 xx
        xx xx xx    xx 21 xx
        */

    //Similar to the first row, this line of code will return the first row second column value for the result matrix.
    left.entries[0, 0] * right.entries[0, 1] + left.entries[0, 1] * right.entries[1, 1] + left.entries[0, 2] * right.entries[2, 1],

    //same thing here where i get the value for first row third column for result matrix.
    left.entries[0, 0] * right.entries[0, 2] + left.entries[0, 1] * right.entries[1, 2] + left.entries[0, 2] * right.entries[2, 2],

    //Second row first to third columns for result matrix.
    left.entries[1, 0] * right.entries[0, 0] + left.entries[1, 1] * right.entries[1, 0] + left.entries[1, 2] * right.entries[2, 0],
    left.entries[1, 0] * right.entries[0, 1] + left.entries[1, 1] * right.entries[1, 1] + left.entries[1, 2] * right.entries[2, 1],
    left.entries[1, 0] * right.entries[0, 2] + left.entries[1, 1] * right.entries[1, 2] + left.entries[1, 2] * right.entries[2, 2],
    
    //Third row first to third column for result matrix.
    left.entries[2, 0] * right.entries[0, 0] + left.entries[2, 1] * right.entries[1, 0] + left.entries[2, 2] * right.entries[2, 0],
    left.entries[2, 0] * right.entries[0, 1] + left.entries[2, 1] * right.entries[1, 1] + left.entries[2, 2] * right.entries[2, 1],
    left.entries[2, 0] * right.entries[0, 2] + left.entries[2, 1] * right.entries[1, 2] + left.entries[2, 2] * right.entries[2, 2]
    );
    }

    public static bool operator ==(HMatrix2D left, HMatrix2D right)
    {
        for(int x = 0; x < 3; x++)     //row
        {
            for (int y = 0; y < 3; y++) //col
            {
                //check all and if got difference in one value within the same row and column then its false. 
                if (left.entries[x, y] != right.entries[x, y]) {
                    return false;
                }
            }
        }
        //If check finish no issues then both matrices are equal and this will return true.
        return true; 
    }

    public static bool operator !=(HMatrix2D left, HMatrix2D right)
    {
        for (int x = 0; x < 3; x++)     //row
        {
            for (int y = 0; y < 3; y++) //col
            {
                //check all and if got difference in one value within the same row and column then its true.
                if (left.entries[x, y] != right.entries[x, y])
                {
                    return true;
                }
            }
        }
        //Otherwise if there was no difference in values, the matrices are the same and this will return false.
        return false;
    }

    //public override bool Equals(object obj)
    //{
        // your code here
    //}

    //public override int GetHashCode()
    //{
        // your code here
    //}

    //public HMatrix2D transpose()
    //{
        //return // your code here
    //}

    //public float getDeterminant()
    //{
        //return // your code here
    //}

    public void setIdentity()
    {
        for (int x = 0; x < 3; x++)     //row
        {
            for (int y = 0; y < 3; y++) //col
            {
                //A simplified version of checking for whether x = y and if it is true, then set value in row x and col y to be 1, otherwise set to 0.
                entries[x, y] = x == y ? 1 : 0; 
                //if (x == y)
                //{
                //entries[x,y] = 1;
                //}

                //else
                //{
                //entries[x, y] = 0;
                //}
            }
        }
    }

    public void setTranslationMat(float transX, float transY)
    {
        /*
        set the translation matrix to 
        1 0 0
        0 1 0
        0 0 1
        */
        setIdentity();

        //Then set the values for first row third column and second row third column to transX and transY respectively so that they can be used in a 3x3 matrix multiplication for 2D.
        entries[0, 2] = transX;
        entries[1, 2] = transY;
    }

    public void setRotationMat(float rotDeg)
    {
        /*
        set the translation matrix to 
        1 0 0
        0 1 0
        0 0 1
        */
        setIdentity();

        //As Mathf uses radians instead of Degrees, we first have to convert the angle input into radians.
        float rad = rotDeg * Mathf.Deg2Rad;

        /*
        Afterwards we set the rotation matrix to be 
        Cos(rad) -Sin(rad) 0
        Sin(rad)  Cos(rad) 0
            0        0     1
        */
        //First row
        entries[0, 0] = Mathf.Cos(rad);
        entries[0, 1] = -Mathf.Sin(rad);

        //Second row
        entries[1, 0] = Mathf.Sin(rad);
        entries[1, 1] = Mathf.Cos(rad);
    }

    //public void setScalingMat(float scaleX, float scaleY)
    //{
        // your code here
    //}

    public void Print()
    {
        string result = "";
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                //Prints out the all values for the matrix row by column
                result += entries[r, c] + "  "; 
            }
            result += "\n";
        }
        Debug.Log(result);
    }
}
