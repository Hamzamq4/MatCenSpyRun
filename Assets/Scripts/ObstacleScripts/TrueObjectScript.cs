using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrueObjectScript : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject radio;
    public AudioClip audioclip;
    public AudioClip[] feedbackClip;

    public GameObject particleSystemPrefab;

    void Start() 
    {
    GameObject radio = GameObject.FindGameObjectWithTag("Radio");
    audioSource = radio.GetComponent<AudioSource>();

    if(gameObject.tag == "MinimalPairsTrue")
        {
            audioSource.PlayOneShot(audioclip);
        }
    }
    void Update()
    {   
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if this object is the true object
        if (gameObject.tag == "MinimalPairsTrue")
        {
            if (other.gameObject.tag == "Player")
            {
                audioSource.PlayOneShot(feedbackClip[Random.Range(0, feedbackClip.Length)]);
                
                TrueObjectScript[] scriptInstances = FindObjectsOfType<TrueObjectScript>();
                foreach (TrueObjectScript scriptInstance in scriptInstances) 
                {
                    // Access the GameObject with the script
                    GameObject wrongObject = scriptInstance.gameObject;
                    Instantiate(particleSystemPrefab, wrongObject.gameObject.transform.position, Quaternion.identity);
                    Destroy(wrongObject);
                }
                Destroy(gameObject);
                Debug.Log("Player survived");   
            }
        }
    }
}

