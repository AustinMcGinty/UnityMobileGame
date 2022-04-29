using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles Spawning a new tile and destroying this one
/// upon the player reaching the end
/// </summary>
public class TileEndBehaviour : MonoBehaviour
{
    [Tooltip("How much time to wait before destorying " +
             "the tile after reaching the end")]
    public float destroyTime = 1.5f;

    private void OnTriggerEnter(Collider col)
    {
        //First Check if we collided with the player
        if (col.gameObject.GetComponent<PlayerBehaviour>())
        {
            // If we did, spawn a new tile
            GameObject.FindObjectOfType<GameController>().SpawnNextTile();

            //And destroy this entire tile after a shot delay
            Destroy(transform.parent.gameObject, destroyTime);
        }
    }
}
