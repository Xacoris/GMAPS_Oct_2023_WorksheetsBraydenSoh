using UnityEngine;
using System.Collections;

namespace pool
{
    public class PongBall : MonoBehaviour
    {
        // Note that the ball can have different X and Y speeds. 
        //
        public float speedX = 4.0f;
        public float speedY = 2.0f;

        // The ball is actually a square Sprite with the image of a circle.
        // ballTop, etc., are declared to make the HandleBoundaryCollision
        // code more intuitive (we think in terms of the top, bottom, left
        // and right of a ball, rather than as offsets from its centre).
        //
        private float radius, ballTop, ballBottom, ballLeft, ballRight;

        // We could have these as public properties in the Inspector, but 
        // they are not used in any other classes, so keep them private &
        // obtain refernces to the game objects in Start().
        //
        private GameObject leftWall, rightWall, topWall, bottomWall;

        // wallOffset is the distance from the center of a wall to its inner edge 
        // (that the ball collides with). The height of the horizontal (top/bottom)
        // walls is the same as the width of the vertical (left/right) walls.
        //
        // wallOffset is used is to stop the ball from penetrating the walls (see 
        // your lecture slides).
        //
        float wallOffset;

        // References to the paddles, needed to check for collisions with
        // each paddle, in HandlePaddleCollision().
        //
        private GameObject leftPaddle, rightPaddle;
        private float paddleHeight, paddleWidth;

        // Just for debugging, to draw a line to show the ball's path.
        // Used in FixedUpdate().
        //
        private Vector3 lastpos;

        void Start()
        {
            // https://stackoverflow.com/questions/23535304/getting-the-width-of-a-sprite
            //
            radius = GetComponent<SpriteRenderer>().sprite.bounds.size.x / 2f;

            leftWall = GameObject.Find("LeftWall");
            rightWall = GameObject.Find("RightWall");
            topWall = GameObject.Find("TopWall");
            bottomWall = GameObject.Find("BottomWall");

            wallOffset = topWall.GetComponent<SpriteRenderer>().sprite.bounds.size.y / 2f;

            leftPaddle = GameObject.Find("LeftPaddle");
            rightPaddle = GameObject.Find("RightPaddle");

            paddleHeight = leftPaddle.GetComponent<SpriteRenderer>().sprite.bounds.size.y;
            paddleWidth = leftPaddle.GetComponent<SpriteRenderer>().sprite.bounds.size.x;

            lastpos = transform.position;
        }

        void HandleBoundaryCollision()
        {
            float xpos, ypos;
                //Compare rightwall position with offset with the right side of the ball and
            if (transform.position.x + radius > rightWall.transform.position.x - wallOffset
                //Compare leftwall position with offset with the left side of the ball to see if the walls and ball collide
                || transform.position.x - radius < leftWall.transform.position.x + wallOffset) 
            {   
                //Checks the speed value along X axis. Since it is positive, the ball would be moving towards the right.
                if (speedX > 0f) 
                {
                    //Set xpos to where the ball would be on the x axis when the ball collides with rightwall.
                    //Without this, cannot constrain ball inside box.
                    xpos = rightWall.transform.position.x - wallOffset - radius; 
                }
                //Checks the speed value along X axis. If it is negative, the ball would be moving towards the left.
                else 
                {
                     //Set xpos to where the ball would be on the x axis when the ball collides with leftwall.
                     xpos = leftWall.transform.position.x + wallOffset + radius;
                    ;
                }
                //set ball position along x axis using xpos so that the ball will not move beyond the right wall and left wall. As in it will not fly out but instead will stay in the box.
                transform.position = new Vector3(xpos,
                                                 transform.position.y,
                                                 transform.position.z);
                //After that, invert the speed to ensure the ball moves in the opposite direction of the initial collision.
                speedX = -speedX;
                ;
            }

            //Compare topwall position with offset with the top side of the ball and
            if (transform.position.y + radius > topWall.transform.position.y - wallOffset
                //Compare bottomwall position with offset with the bottom side of the ball to see if the walls and ball collide
                || transform.position.y - radius < bottomWall.transform.position.x + wallOffset)
            {
                //Checks the speed value along Y axis. Since it is positive, the ball would be moving up.
                if (speedY > 0f)
                {   
                    //Set ypos to where the ball would be on the y axis when the ball collides with topwall.
                    ypos = topWall.transform.position.y - wallOffset - radius;
                }
                //Checks the speed value along Y axis. If it is negative, the ball would be moving down.
                else
                {
                    //Set ypos to where the ball would be on the y axis when the ball collides with bottomwall.
                    ypos = bottomWall.transform.position.y + wallOffset + radius;
                    ;
                }
                //set ball position along y axis using ypos so that the ball will not move beyond the top wall and bottom wall. As in it will not fly out but instead will stay in the box.
                transform.position = new Vector3(transform.position.x,
                                                 ypos,
                                                 transform.position.z);
                //After that, invert the speed to ensure the ball moves in the opposite direction of the initial collision.
                speedY = -speedY;
                ;
            }
        }

        void HandlePaddleCollision()
        {
            if (transform.position.x < leftPaddle.transform.position.x + paddleWidth / 2
               && transform.position.y < leftPaddle.transform.position.y + paddleHeight / 2
               && transform.position.y > leftPaddle.transform.position.y - paddleHeight / 2)
            {
                transform.position = new Vector3(leftPaddle.transform.position.x + paddleWidth / 2f + radius,
                                                 transform.position.y,
                                                 transform.position.z);
                speedX = -speedX;
            }
            // ball right is greater than paddle left
            if (transform.position.x + radius > rightPaddle.transform.position.x - paddleWidth / 2f
                // bottom of ball is less than paddle top
                && transform.position.y - radius < rightPaddle.transform.position.y + paddleHeight / 2f
                // top of ball is greater than paddle bottom
                && transform.position.y + radius > rightPaddle.transform.position.y - paddleHeight / 2f)
            {
                transform.position = new Vector3(rightPaddle.transform.position.x - (paddleWidth / 2f) - radius,
                                                 transform.position.y,
                                                 transform.position.z);
                speedX = -speedX;
            }
        }

        void FixedUpdate()
        {
            Debug.DrawLine(lastpos, transform.position, Color.red, 5f);
            lastpos = transform.position;

            transform.Translate(new Vector2(speedX * Time.deltaTime,
                                            speedY * Time.deltaTime));

            // Move this to the top of FixedUpdate and see what happens
            ballTop = transform.position.y + radius;
            ballBottom = transform.position.y - radius;
            ballLeft = transform.position.x - radius;
            ballRight = transform.position.x + radius;
            // 

            HandleBoundaryCollision();
            HandlePaddleCollision();
        }
    }
}

