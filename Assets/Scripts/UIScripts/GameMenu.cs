using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

[System.Serializable]
public class GameMenu : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject gameOverPanel;
    public GameObject scoreUI;
    public GameObject fromMenu;
    public Animation run;
    private Animator pAnimator;


    public Button pause, genoptag, pauseAfslut, tryAgain, gameOverAfslut;

    // Start is called before the first frame update. Adds listeners which update the panelName string based on which button is clicked
    void Start()
    {
        pause.onClick.AddListener(delegate { ChangePanel("pause"); });
        genoptag.onClick.AddListener(delegate { ChangePanel("genoptag"); });
        pauseAfslut.onClick.AddListener(delegate { ChangePanel("pauseAfslut"); });
        tryAgain.onClick.AddListener(delegate { ChangePanel("tryAgain"); });
        gameOverAfslut.onClick.AddListener(delegate { ChangePanel("tryAgainAfslut"); });
        fromMenu = GameObject.FindGameObjectWithTag("FromMenu");

    }
    //DisablePanels disable the pause UI panel whenever it is called inside the ChangePanel function
    public void DisablePanels()
    {
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }
    // ChangePanel handles the UI interactions based on the panelName string. Based on the button selected, it either disables the panels and continues the game, reloads the current scene or loads the menu scene
    public void ChangePanel(string panelName)
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        switch (panelName)
        {
            case "pause":
                Debug.Log("Pause");
                DisablePanels();
                pause.gameObject.SetActive(false);
                Time.timeScale = 0;
                pausePanel.SetActive(true);
                break;
            case "genoptag":
                Debug.Log("Genoptag");
                DisablePanels();
                pause.gameObject.SetActive(true);
                Time.timeScale = 1;
                break;
            case "pauseAfslut":
                Debug.Log("PauseAfslut");
                DisablePanels();
                SceneManager.LoadScene("MenuScene");
                Time.timeScale = 1;
                scoreUI.gameObject.SetActive(true);
                ScoreManager.health = 2;
                break;
            case "tryAgain":
                Debug.Log("Prøv igen");
                Destroy(fromMenu);
                DisablePanels();
                Time.timeScale = 1;
                SceneManager.LoadScene(currentSceneName);
                scoreUI.gameObject.SetActive(true);
                ScoreManager.health = 2;
                ResetDeath();
                break;
            case "tryAgainAfslut":
                Debug.Log("TryAgainAfslut");
                ResetDeath();
                DisablePanels();
                Time.timeScale = 1;
                SceneManager.LoadScene("MenuScene");
                scoreUI.gameObject.SetActive(true);
                ScoreManager.health = 2;
                break;
        }
    }

    private void ResetDeath()
    {
        GameObject player = GameObject.FindWithTag("Player");
        Animator playerAnimator = player.GetComponent<Animator>();
        //playerAnimator.ResetTrigger("Death_b");
        playerAnimator.SetBool("Death_b", false);
        ScoreManager.isPlayerAlive = true;
    }
       
}
