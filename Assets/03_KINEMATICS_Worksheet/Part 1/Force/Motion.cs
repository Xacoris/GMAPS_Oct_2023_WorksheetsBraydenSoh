using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    public Vector3 Velocity;

    void FixedUpdate()
    {
        float dt = Time.deltaTime;

        //multiplies the velocity of the object by Time.deltaTime so that the velocity increases as time increases.
        float dx = Velocity.x * dt;
        float dy = Velocity.y * dt;
        float dz = Velocity.z * dt;

        //As this is fixed update, this will constantly move the object based on its velocity
        transform.Translate(new Vector3(dx,dy,dz));
    }
}
