using UnityEngine;

public class MeshManager : MonoBehaviour
{
    private MeshFilter meshFilter;

    [HideInInspector]
    public Mesh originalMesh, clonedMesh;

    public Vector3[] vertices { get; private set; }
    public int[] triangles { get; private set; }

    void Awake()
    {
        //Obtains the MeshFilter component from the sonic gameObject to be referenced later.
        meshFilter = GetComponent<MeshFilter>();
        
        //Sets originalMesh to the sonic gameObject's original mesh values.
        originalMesh = meshFilter.sharedMesh;

        //Creates a new mesh call clonedMesh which will take in values from originalMesh to literally become a clone of the originalMesh.
        clonedMesh = new Mesh();
        clonedMesh.name = "clone";
        clonedMesh.vertices = originalMesh.vertices;
        clonedMesh.triangles = originalMesh.triangles;
        clonedMesh.normals = originalMesh.normals;
        clonedMesh.uv = originalMesh.uv;

        //Afterwards, set the mesh of the sonic gameObject to be clonedMesh.
        meshFilter.mesh = clonedMesh;

        //Also set the vertices and triangles of the mesh to that of clonedMesh.
        vertices = clonedMesh.vertices;
        triangles = clonedMesh.triangles;
    }
}
