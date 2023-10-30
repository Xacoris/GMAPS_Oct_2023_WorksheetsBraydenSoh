using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMatrix : MonoBehaviour
{
    private HMatrix2D mat = new HMatrix2D();
    // Start is called before the first frame update
    void Start()
    {
        mat.setIdentity();
        mat.Print();
        Question2();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Question2()
    {
        HMatrix2D mat1 = new HMatrix2D(1,2,3,4,5,6,7,8,9);
        HMatrix2D mat2 = new HMatrix2D(-2,1,7,4,-2,-4,5,-7,8);
        HMatrix2D resultMat = new HMatrix2D();
        HVector2D vec1 = new HVector2D(3,4);
        HVector2D resultVec = new HVector2D();

        resultMat = mat1 * mat2;
        print(resultMat);
        resultVec = mat2 * vec1;
        Debug.Log(resultVec);
    }
}
