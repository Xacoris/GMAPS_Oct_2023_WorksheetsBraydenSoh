using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioHVector2D : MonoBehaviour
{
    public Transform planet;
    public float force = 5f;
    public float gravityStrength = 5f;

    private HVector2D gravityDir, gravityNorm;
    private HVector2D moveDir;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        gravityDir = new HVector2D(planet.position - transform.position);  
        moveDir = new HVector2D(gravityDir.y, -gravityDir.x);

        moveDir = moveDir.normalized * -1f;

        rb.AddForce(moveDir * force, ForceMode2D.Force);

        gravityNorm = gravityDir.normalized;


        rb.AddForce(gravityNorm * gravityStrength, ForceMode2D.Force);


        float angle = Vector3.SignedAngle(Vector3.down, gravityDir, Vector3.forward);

        rb.MoveRotation(Quaternion.Euler(0, 0, angle));

        DebugExtension.DebugArrow(transform.position, gravityDir, Color.red);

        DebugExtension.DebugArrow(transform.position, moveDir, Color.blue);
    }
}
