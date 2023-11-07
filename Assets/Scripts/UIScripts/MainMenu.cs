using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script serves as the main functionality for the initial screen upon opening the game. 
/// </summary>

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject aboutPanel;
    public GameObject characterPanel;
    public GameObject howToPanel;
    public GameObject descriptionPanel;
    public GameObject startPanel;

    public Button start, fremskridt, indstillinger, traffik, skole, snebjerge, about, character, howTo, description;

    void Start() // adds listeners that detect when a click event occurs
    {
        start.onClick.AddListener(delegate { ChangePanel("start"); });
        about.onClick.AddListener(delegate { ChangePanel("about"); });
        character.onClick.AddListener(delegate { ChangePanel("character"); });
        howTo.onClick.AddListener(delegate { ChangePanel("howTo"); });
        description.onClick.AddListener(delegate { ChangePanel("description"); });

        traffik.onClick.AddListener(delegate { ChangeScene("traffik");});
        skole.onClick.AddListener(delegate { ChangeScene("skole");});
        snebjerge.onClick.AddListener(delegate { ChangeScene("snebjerge"); });

    }

    public void DisablePanels() // adds listeners that detect when a click event occurs

    {
        mainMenuPanel.SetActive(false);
        aboutPanel.SetActive(false);
        characterPanel.SetActive(false);
        startPanel.SetActive(false);
        howToPanel.SetActive(false);
        descriptionPanel.SetActive(false);
    }

    public void ChangePanel(string panelName) //the start screen, fremskridt screen and settings screen. 
    {
        switch (panelName)
        {
            case "start":
                DisablePanels();
                startPanel.SetActive(true);
                break;
            case "about":
                DisablePanels();
                aboutPanel.SetActive(true);
                Debug.Log("test");
                break;
            case "character":
                DisablePanels();
                characterPanel.SetActive(true);
                break;
            case "howTo":
                DisablePanels();
                howToPanel.SetActive(true);
                break;
            case "description":
                DisablePanels();
                descriptionPanel.SetActive(true);
                break;
        }
    }

    public void BackButton()
    {
        DisablePanels();
        mainMenuPanel.SetActive(true);
    }

        public void ChangeScene(string sceneName)
    {
        if (sceneName == "traffik")
        {
            SceneManager.LoadScene("TraffikScene");
        }
        else if (sceneName == "skole")
        {
            SceneManager.LoadScene("SkoleScene");
        }
        else if (sceneName == "snebjerge")
        {
            SceneManager.LoadScene("VikingScene");
        }
    }
}
