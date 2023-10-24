using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SoccerPlayer : MonoBehaviour
{
    public bool IsCaptain = false;
    public SoccerPlayer[] OtherPlayers;
    public float rotationSpeed = 1f;

    float angle = 0f;

    private void Start()
    {
        OtherPlayers = FindObjectsOfType<SoccerPlayer>().Where(t => t != this).ToArray();
        if (IsCaptain)
        {
            FindMinimum();
        }
        //OtherPlayers = FindObjectsOfType<SoccerPlayer>();
        //SoccerPlayer[] temp = new SoccerPlayer[OtherPlayers.Length - 1];
        //int i = 0;
        //foreach (SoccerPlayer p in OtherPlayers)
        //{
            //if (p != this)
            //{
                //temp[i] = p;
                //i++;
            //}
        //}
        //OtherPlayers = temp;
        //Debug.Log(OtherPlayers.Length);
    }

    float Magnitude(Vector3 vector)
    {
        return (float)Mathf.Sqrt(vector.x * vector.x + vector.y * vector.y);
    }

    Vector3 Normalise(Vector3 vector)
    {
        float mag = Magnitude(vector);
        vector.x /= mag;
        vector.y /= mag;
        vector.z /= mag;
        return vector;
    }

    float Dot(Vector3 vectorA, Vector3 vectorB)
    {
        return (vectorA.x * vectorB.x + vectorA.y * vectorB.y);
    }

    SoccerPlayer FindClosestPlayerDot()
    {
        SoccerPlayer closest = null;
        float minAngle = 180f;

        for(int i = 0; i < OtherPlayers.Length; i++)
        {
            Vector3 toPlayer = OtherPlayers[i].transform.position - transform.forward ;
            Vector3 toPlayerNorm = Normalise(toPlayer);

            float dot = Dot(toPlayerNorm, Normalise(Vector3.forward));
            float angle = Mathf.Acos(dot);
            angle = angle * Mathf.Rad2Deg;

            if (angle < minAngle)
            {
                minAngle = angle;
                closest = OtherPlayers[i];
                Debug.Log(closest);
                Debug.Log(OtherPlayers[0]);
            }
        }
        return closest;
    }

    void DrawVectors()
    {
        foreach (SoccerPlayer other in OtherPlayers)
        {
            Debug.DrawRay(transform.position, (other.transform.position - transform.position), Color.black);
        }
    }

    void FindMinimum()
    {
        float test = 21f;
        for(int i = 0; i < 10; i++)
        {
            float height = Random.Range(5f, 20f);
            if (height < test)
            {
                test = height * 1;
            }

        }
        Debug.Log(test);
    }

    void Update()
    {
        DebugExtension.DebugArrow(transform.position, transform.forward, Color.red);

        if (IsCaptain)
        {
            angle += Input.GetAxis("Horizontal") * rotationSpeed;
            transform.localRotation = Quaternion.AngleAxis(angle, Vector3.up);
            Debug.DrawRay(transform.position, transform.forward * 10f, Color.red);
            DrawVectors();

            SoccerPlayer targetPlayer = FindClosestPlayerDot();
            targetPlayer.GetComponent<Renderer>().material.color = Color.green;
            foreach (SoccerPlayer other in  OtherPlayers.Where(t => t != targetPlayer))
            {
                other.GetComponent<Renderer>().material.color = Color.white;
            }
        }
        
    }
}


