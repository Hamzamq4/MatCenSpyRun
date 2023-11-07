using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class coinPicker : MonoBehaviour
{
    public GameObject gameManager;


    // Start is called before the first frame update
    void Start()
    {
        ScoreManager scoreManager = gameManager.GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    // Handles collection detection of coins and increments the scoreCount variable inside of the ScoreManager script placed on the GameManager object
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            ScoreManager scoreManager = gameManager.GetComponent<ScoreManager>();

            Destroy(other.gameObject);
            scoreManager.scoreCount++;
            
        }

    }

}
