using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 30.0f; // Adjust this to control the rotation speed.

    // Update is called once per frame
    void Update()
    {
        // Rotate the object around its local Y-axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.Self);
    }
}
