using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FromMenuAudio : MonoBehaviour
{   
    public AudioClip longIntro;
    public AudioSource radio;
    public GameObject gameManager;

    private bool hasPlayedIntro = false;
    private int activeScene;

    private static FromMenuAudio instance;

    private void Awake()
    {
        // Check if an instance already exists
        if (instance == null)
        {
            // If not, set this as the instance
            instance = this;
            // Don't destroy this object when loading new scenes
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If an instance already exists, destroy this one
            Destroy(gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameManager = GameObject.FindGameObjectWithTag("GameManager");

    }

    // Update is called once per frame
    void Update()
    {
    activeScene = SceneManager.GetActiveScene().buildIndex;
    if(!hasPlayedIntro)
    {
        if(activeScene != 0)
        {
        GameObject radioObject = GameObject.FindGameObjectWithTag("Radio");
        radio = radioObject.GetComponent<AudioSource>();
        radio.clip = longIntro;
        radio.Play();
        hasPlayedIntro = true;

        GameObject gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameManager.GetComponent<ObstacleGenerator>().spawnStartTime = 15;
        }
    }
    }
}
