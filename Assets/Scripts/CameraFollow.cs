using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // Reference to the player's transform
    public Vector3 offset;    // Offset of the camera from the player

    // Start is called before the first frame update
    void Start()
    {
        // Optional: Initialize the offset if it's not set in the Unity Inspector
        if (offset == Vector3.zero)
        {
            offset = transform.position - player.position; // Default offset calculation
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Update the camera's X position to follow the player, while keeping Y and Z fixed
        transform.position = new Vector3(player.position.x + offset.x, transform.position.y, transform.position.z);
    }
}
