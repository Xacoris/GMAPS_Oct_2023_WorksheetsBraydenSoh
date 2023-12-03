using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLaw : MonoBehaviour
{
    public Vector3 force;
    Rigidbody rb;

    void Start()
    {
        //Gets the rigidbody component so that I can use AddForce to move the object to the right.
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.right, ForceMode.Force);
     }

    void FixedUpdate()
    {
        //debugs the object's current position
        Debug.Log(transform.position);
    }
}

