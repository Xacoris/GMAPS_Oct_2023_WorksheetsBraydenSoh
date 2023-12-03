using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpToHeight : MonoBehaviour
{
    public float Height = 1f;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Jump()
    {
        // v*v = u*u + 2as
        // u*u = v*v - 2as
        // u = sqrt(v*v - 2as)
        // v = 0, u = ?, a = Physics.gravity, s = Height

        //uses Suvat equation to find u whereby u will become the square root of -2 times of gravity
        float u = Mathf.Sqrt(-2 * Physics.gravity.y * Height);
        //sets the object's y axis velocity to u
        rb.velocity = new Vector3(0, u , 0);


        /*
        same function as above where by it moves the objects up.
        float jumpForce = Mathf.Sqrt(-2 * Physics2D.gravity.y * Height);
        rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        */
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump
            ();
        }
    }
}

