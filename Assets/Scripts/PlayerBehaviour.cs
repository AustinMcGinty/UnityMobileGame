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
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        //check if we're moving to the side
        var horizontalSpeed = Input.GetAxis("Horizontal") * dodgeSpeed;

        // Apply our auto-moving and movement forces
        rb.AddForce(horizontalSpeed, 0, rollSpeed);
    }
}
