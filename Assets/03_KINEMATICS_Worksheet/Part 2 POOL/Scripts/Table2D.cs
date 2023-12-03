using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table2D : MonoBehaviour
{
    public List<Ball2D> balls;

    private void Start()
    {

    }

    bool CheckBallCollision(Ball2D toCheck)
    {
        for (int i = 0; i < balls.Count; i++)
        {
            //sets Ball2D ball to the ball in List balls based on index i
            Ball2D ball = balls[i];
            
            //if ball collides with cueball, return true
            if (ball.IsCollidingWith(toCheck) && toCheck != ball)
            {
                return true;
            }
        }

        //else return false
        return false;
    }

    private void FixedUpdate()
    {
        //if CheckBallCollision with cueball returns true, debug COLLISION!
        if (CheckBallCollision(balls[0]))
        {
            Debug.Log("COLLISION!");
        }
    }
}
