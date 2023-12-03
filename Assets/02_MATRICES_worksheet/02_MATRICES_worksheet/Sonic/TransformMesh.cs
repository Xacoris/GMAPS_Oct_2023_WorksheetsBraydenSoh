//using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformMesh : MonoBehaviour
{
    [HideInInspector]
    public Vector3[] vertices { get; private set; }

    private HMatrix2D transformMatrix = new HMatrix2D();
    HMatrix2D toOriginMatrix = new HMatrix2D();
    HMatrix2D fromOriginMatrix = new HMatrix2D();
    HMatrix2D rotateMatrix = new HMatrix2D();

    private MeshManager meshManager;
    HVector2D pos = new HVector2D();

    void Start()
    {
        meshManager = GetComponent<MeshManager>();
        //set HVector2D variable pos to the original position of the gameObject
        pos = new HVector2D(gameObject.transform.position.x, gameObject.transform.position.y);

        // Your code here
        Rotate(45);
        //Translate(1, 1);
    }


    void Translate(float x, float y)
    {
        //sets transformMatrix to Identity matrix before adding in the values for translating along x and y axis in setTranslationMat.
        transformMatrix.setIdentity();
        transformMatrix.setTranslationMat(x,y);
        Transform();

        //set the position of the gameobject to the new position after translating.
        pos = transformMatrix * pos;
    }

    void Rotate(float angle)
    {
        //create 3 new matrices for moving to origin, rotating the gameObject and moving back.
        HMatrix2D toOriginMatrix = new HMatrix2D();
        HMatrix2D rotateMatrix = new HMatrix2D();
        HMatrix2D fromOriginMatrix = new HMatrix2D();

        //Set the values of the matrices using the functions from HMatrix2D
        //Sets values for toOriginMatrix as the negative of the current position so that the new position is 0,0
        toOriginMatrix.setTranslationMat(-pos.x,-pos.y);
        //Sets values for fromOriginMatrix as the current position so that the new position is the original position
        fromOriginMatrix.setTranslationMat(pos.x,pos.y);
        //sets values of the rotation matrix based on the given angle
        rotateMatrix.setRotationMat(angle);

        //Set transformMatrix to identity matrix before changing the values to the product of the 3 prior matrices.
        transformMatrix.setIdentity();

        // Your code here

        transformMatrix = fromOriginMatrix * rotateMatrix * toOriginMatrix;
        // Your code here;

        //call the transform function to translate and rotate the gameobject.
        Transform();
    }

    private void Transform()
    {
        vertices = meshManager.clonedMesh.vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            // Your code here
            //foreach of the vertices in the cloned mesh, multiply its position by the transformMatrix so that the cloned mesh will translate and or rotate.
            HVector2D vert = new HVector2D(vertices[i].x, vertices[i].y);
            vert = transformMatrix * vert;
            vertices[i].x = vert.x;
            vertices[i].y = vert.y;
        }

        //set clonedMesh vertices to be the new vertices values.
        meshManager.clonedMesh.vertices = vertices;
    }
}
