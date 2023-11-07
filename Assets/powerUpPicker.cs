using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class powerUpPicker : MonoBehaviour
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
        if (other.gameObject.CompareTag("powerUp")) // Use CompareTag for efficiency
        {
            ScoreManager scoreManager = gameManager.GetComponent<ScoreManager>();

            // Set the scoreMultiplier to true for 10 seconds
            scoreManager.defaultMultiplier = false;
            StartCoroutine(ResetScoreMultiplier(10f)); // Reset it after 10 seconds
            Destroy(other.gameObject);
        }
    }

    private IEnumerator ResetScoreMultiplier(float multiplierTime)
    {
        yield return new WaitForSeconds(multiplierTime);
        ScoreManager scoreManager = gameManager.GetComponent<ScoreManager>();
        scoreManager.defaultMultiplier = true;
    }
}


