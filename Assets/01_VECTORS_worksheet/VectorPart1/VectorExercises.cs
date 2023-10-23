using UnityEngine;

public class VectorExercises : MonoBehaviour
{
    [SerializeField] LineFactory lineFactory;
    [SerializeField] bool Q2a, Q2b, Q2c, Q2d, Q2e;
    [SerializeField] bool Q3a, Q3b, Q3c, projection;

    private Line drawnLine;

    private Vector2 startPt;
    private Vector2 endPt;

    public float GameWidth, GameHeight;
    private float minX, minY, maxX, maxY;

    private void Start()
    {   
        if (Q2c)
            CalculateGameDimensions();
        if (Q2a)
            Question2a();
        if (Q2b)
            Question2b(20);
        if (Q2d)
            Question2d();
        if (Q2e)
            Question2e(20);
        if (Q3a)
            Question3a();
        if (Q3b)
            Question3b();
        if (Q3c)
            Question3c();
        if (projection)
            Projection();
    }

    public void CalculateGameDimensions()
    {
        GameHeight = Camera.main.orthographicSize * 2f;     //This i believe based on unity documentation is half of the total y axis provided in orthographic to maybe show positive and negative y axis in relation to the center on the screen/camera.
        GameWidth = Camera.main.aspect * GameHeight;        //aspect = width/height so thats why we multiply in height to get width

        maxX = GameWidth / 2;
        maxY = GameHeight / 2;
        minX = -maxX;
        minY = -maxY;
    }

    void Question2a()
    {
        startPt = new Vector2(0, 0);
        endPt = new Vector2(2, 3);

        drawnLine = lineFactory.GetLine(startPt, endPt, 0.02f, Color.black);

        drawnLine.EnableDrawing(true);

        Vector2 vec2 = endPt - startPt;
        Debug.Log("Magnitude = " + vec2.magnitude);
    }

    void Question2b(int n)
    {
        //maxX = 5;
        //maxY = 5;
        for (int i = 0; i < n; i++)
        {
        startPt = new Vector2(Random.Range(-maxX, maxX), Random.Range(-maxY, maxY));

            endPt = new Vector2(Random.Range(-maxX, maxX), Random.Range(-maxY, maxY));

        drawnLine = lineFactory.GetLine(startPt, endPt, 0.02f, Color.black);
        drawnLine.EnableDrawing(true);
        Debug.Log(maxX);
        }
    }

    void Question2d()
    {
        DebugExtension.DebugArrow(
        new Vector3(0, 0, 0),
        new Vector3(5, 5, 5),
        Color.red,
        60f);
        

    }

    void Question2e(int n)
    {
        for (int i = 0; i < n; i++)
        {
            startPt = new Vector2(
                Random.Range(-maxX, maxX), 
                Random.Range(-maxY, maxY));

            // Your code here
            // ...

            DebugExtension.DebugArrow(
                new Vector3(0, 0, 0),
                new Vector3(Random.Range(-maxX, maxX), Random.Range(-maxY, maxY), Random.Range(-maxX, maxX)),
                Color.white,
                60f);
        }  
    }

    public void Question3a()
    {
        HVector2D a = new HVector2D(3, 5);
        HVector2D b = new HVector2D(-4, 2);
        //HVector2D c = a + b;
        HVector2D c = a - b;

        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);

        DebugExtension.DebugArrow(Vector3.zero, b.ToUnityVector3(), Color.green, 60f);

        //DebugExtension.DebugArrow(a.ToUnityVector3(), b.ToUnityVector3(), Color.green, 60f);
        DebugExtension.DebugArrow(a.ToUnityVector3(), -b.ToUnityVector3(), Color.green, 60f);

        DebugExtension.DebugArrow(Vector3.zero, c.ToUnityVector3(), Color.white, 60f);

        Debug.Log("Magnitude of a = " + a.Magnitude().ToString("F2"));
        Debug.Log("Magnitude of b = " + b.Magnitude().ToString("F2"));
        Debug.Log("Magnitude of c = " + c.Magnitude().ToString("F2"));
        // Your code here
        // ...
    }

    public void Question3b()
    {
        HVector2D a = new HVector2D(3, 5);
        //HVector2D b = a * 2;
        HVector2D b = a / 2;

        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(Vector3.right, b.ToUnityVector3(), Color.green, 60f);
        // Your code here
    }

    public void Question3c()
    {
        HVector2D a = new HVector2D(3, 5);
        HVector2D a2 = new HVector2D(3, 5);
        a2.Normalize();
        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(Vector3.right, a2.ToUnityVector3(), Color.green, 60f);
    }

    public void Projection()
    {
        HVector2D a = new HVector2D(0, 0);
        HVector2D b = new HVector2D(6, 0);
        HVector2D c = new HVector2D(2, 2);

        

        DebugExtension.DebugArrow(a.ToUnityVector3(), b.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(a.ToUnityVector3(), c.ToUnityVector3(), Color.yellow, 60f);
        
        HVector2D v1 = b - a;
        HVector2D v2 = c - a;

        HVector2D proj = v2.Projection(v1);

        DebugExtension.DebugArrow(a.ToUnityVector3(), proj.ToUnityVector3(), Color.white, 60f);
    }
}
