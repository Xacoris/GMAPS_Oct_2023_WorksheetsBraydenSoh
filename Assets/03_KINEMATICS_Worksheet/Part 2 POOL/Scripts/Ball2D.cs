using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball2D : MonoBehaviour
{
    public HVector2D Position = new HVector2D(0, 0);
    public HVector2D Velocity = new HVector2D(0, 0);

    [HideInInspector]
    public float Radius;

    private void Start()
    {
        //Sets the position HVector2D variable to the current position of the ball
        Position.x = transform.position.x;
        Position.y = transform.position.y;

        //Gets the sprite componenet for the ball so that the radius can be obtained to check for collision.
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Vector2 sprite_size = sprite.rect.size;
        Vector2 local_sprite_size = sprite_size / sprite.pixelsPerUnit;
        Radius = local_sprite_size.x / 2f;

        HVector2D a = new HVector2D(8f, 5f);
        HVector2D b = new HVector2D(1f, 3f);
        //Gets distance between HVector2D a and b.
        float distance = Util.FindDistance(a, b);
    }

    public bool IsCollidingWith(float x, float y)
    {
        //Checks if distance from current position to the input vector position is less than or equals to the radius.
        float distance = Util.FindDistance(Position, new HVector2D(x,y));
        //If less than or equals to radius return true, else return false
        return distance <= Radius;
    }

    public bool IsCollidingWith(Ball2D other)
    {
        //Checks distance between the current ball and other ball to see if the distance is less than or equals to the ball's radius and the other ball's radius.
        float distance = Util.FindDistance(Position, other.Position);
        //if it is less than or equals, return true, else return false.
        return distance <= Radius + other.Radius;
    }

    public void FixedUpdate()
    {
        //calls the UpdateBall2DPhysics functions with Time.deltaTime as input.
        UpdateBall2DPhysics(Time.deltaTime);
    }

    private void UpdateBall2DPhysics(float deltaTime)
    {
        //set the position x and y of the ball to the inverse of the velocity multiplied by Time.deltaTime.
        float displacementX = Velocity.x * deltaTime;
        float displacementY = Velocity.y * deltaTime;

        Position.x += -displacementX;
        Position.y += -displacementY;

        //Sets the ball's position based on HVector2D position.
        transform.position = new Vector2(Position.x, Position.y);
    }
}

