using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;

    private void Update()
    {
        // Get the current position of the object
        Vector3 currentPosition = transform.position;

        // Update only the z-axis position to match the player's z-axis position
        currentPosition.z = player.position.z;

        // Assign the updated position back to the object's transform
        transform.position = currentPosition;
    }
}
