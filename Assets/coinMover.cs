using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinMover : MonoBehaviour
{
    public float teleportDistance = 10.0f; // Adjust the teleport distance as needed

    private Animator animator;

    void Start()    
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("staticObstacle"))
        {
            // Teleport the object along the z-axis
            transform.position += Vector3.forward * teleportDistance;
        }

        Debug.Log("Coin Moved");

        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("PlayAnimation");
        }
    }
}



