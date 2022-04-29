using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Will Adjust the Camera to follow and face a target
/// </summary>
public class CameraBehaviour : MonoBehaviour
{
    [Tooltip("What object should the camera be looking at")]
    public Transform target;

    [Tooltip("How offset will the camera be to the target")]
    public Vector3 offset = new Vector3(0, 3, -6);
    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        //Check if target is a vaild object
        if(target != null)
        {
            //set our position to an offset of the target
            transform.position = target.position + offset;

            //change the roatation to face target
            transform.LookAt(target);
        }
    }
}
