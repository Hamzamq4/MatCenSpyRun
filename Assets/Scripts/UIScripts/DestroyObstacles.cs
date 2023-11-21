using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObstacles : MonoBehaviour
{
    public GameObject particleSystemPrefab; // Assign the particle system prefab in the Inspector
    public AudioClip maleDestroySound; // Assign the sound in the Inspector

    public AudioClip femaleDestroySound;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); //Getting audiosource component of player

    }


    // OnTriggerEnter handles collision and deletion of objects which collide with the player. Furthermore, it generates the sound and the animation which plays when colliding
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle") || other.gameObject.CompareTag("staticObstacle"))
        {
            Debug.Log("Collision with " + other.gameObject);
            Destroy(other.gameObject);

            ScoreManager.health -= 1;

            // Instantiate a new particle system at the position of the destroyed gameobject
            Instantiate(particleSystemPrefab, other.gameObject.transform.position, Quaternion.identity);

            GameObject characterGender = GameObject.Find("CharacterDataTransfer");

            CharacterManager characterManager = characterGender.GetComponent<CharacterManager>();

            Debug.Log(characterManager.isFemale);
            
            if (characterManager.isFemale == false)
            {
                if (femaleDestroySound != null)
                {
                audioSource.PlayOneShot(maleDestroySound);

                }
            }

            if (characterManager.isFemale == true)
            {
                if (femaleDestroySound != null)
                {
                    audioSource.PlayOneShot(femaleDestroySound);
                }
        }
    }
}
}
