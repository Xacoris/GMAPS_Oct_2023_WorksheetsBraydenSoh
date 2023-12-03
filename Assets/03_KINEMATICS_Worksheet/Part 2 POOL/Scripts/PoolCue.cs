using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolCue : MonoBehaviour
{
    public LineFactory lineFactory;
    public GameObject ballObject;

    private Line drawnLine;
    private Ball2D ball;

    private void Start()
    {
        //gets component Ball2D script from ball object 
        ball = ballObject.GetComponent<Ball2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Upon holding left click, set startLinePos to the mouse position.
            var startLinePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Start line drawing
            //If the startLinePos is inside the ball object, draw a line from the ball object's position to where the mouse is dragged to in the game scene
            if (ball != null && ball.IsCollidingWith(startLinePos.x,startLinePos.y))
            {   
                //draws line based on starting position, end position, width and color.
                drawnLine = lineFactory.GetLine(ballObject.transform.position,startLinePos,5, Color.black);
                //Set EnableDrawing to true so that the line will appear.
                drawnLine.EnableDrawing(true);
            }
        }
        //if a line has been drawn and i release the left click, 
        else if (Input.GetMouseButtonUp(0) && drawnLine != null)
        {
            //set enable drawing to false to hide the line
            drawnLine.EnableDrawing(false);

            //update the velocity of the white ball.
            HVector2D v = new HVector2D(drawnLine.end - drawnLine.start);
            ball.Velocity = v;

            //Empty the line.
            drawnLine = null; // End line drawing            
        }

        if (drawnLine != null)
        {
            //If a line exists, the end point of the line will constantly be set to the mouse position.
            drawnLine.end = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Update line end
        }
    }

    /// <summary>
    /// Get a list of active lines and deactivates them.
    /// </summary>
    public void Clear()
    {
        var activeLines = lineFactory.GetActive();

        foreach (var line in activeLines)
        {
            line.gameObject.SetActive(false);
        }
    }
}
