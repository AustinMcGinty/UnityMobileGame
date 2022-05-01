using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Responsible for moving the player automatically and
/// reciving input.
/// </summary>
[RequireComponent(typeof(Rigidbody))] // Stops any object using this script from removing it's Rigidbody compoenet

public class PlayerBehaviour : MonoBehaviour
{
    /// <summary>
    /// A reference to the Rigidbody component
    /// </summary>
    private Rigidbody rb;

    //how fast the ball moves left/right
    [Tooltip("How fast the ball moves left/right")]
    public float dodgeSpeed = 5;

    //how fast the ball moves forwards automattically
    [Tooltip("How fast the ball moves forwards automatically")]
    [Range(0,10)]
    public float rollSpeed = 5;

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        //Get access to our Rigidbody Component
        rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Will Figure out where to move the player horizontally
    /// </summary>
    /// <param name="pixelPos">The position the player has touched/clicked on</param>
    /// <returns>The direction to move in the x axis</returns>
    float CalculateMovement (Vector3 pixelPos)
    {
        //Converts to a 0 to 1 scale
        var worldPos = Camera.main.ScreenToViewportPoint(pixelPos);

        float xMove = 0;
        //If we press the right side of the screen
        if (worldPos.x < 0.5f)
        {
            xMove = -1;
        }
        else
        {
            //Otherwise we're on the left
            xMove = 1;
        }

        // replace horizontalSpeed with our own value
        return xMove * dodgeSpeed;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        //check if we're moving to the side
        var horizontalSpeed = Input.GetAxis("Horizontal") * dodgeSpeed;

        //If the Mouse is held down (or the screen is tapped on mobile)
        if (Input.GetMouseButton(0))
        {
            //Converts to a 0 to 1 scale
            var worldPose = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            float xMove = 0;

            //If we press the right side of the screen
            if (worldPose.x < 0.5f)
            {
                xMove = -1;
            }
            else
            {
                //Otherwise we're on the left
                xMove = 1;
            }

            //replace horizotalSpeed with our own vaule
            horizontalSpeed = xMove * dodgeSpeed;
        }
        // Apply our auto-moving and movement forces
        rb.AddForce(horizontalSpeed, 0, rollSpeed);
    }
}
