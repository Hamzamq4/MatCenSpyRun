using UnityEngine;

public class BobbingObject : MonoBehaviour
{
    public float bobSpeed = 1.0f;   // Speed of the bobbing motion
    public float bobHeight = 0.5f;  // Height of the bobbing motion
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Calculate the new position based on the sine wave
        Vector3 newPosition = startPosition + new Vector3(0, Mathf.Sin(Time.time * bobSpeed) * bobHeight, 0);
        transform.position = newPosition;
    }
}