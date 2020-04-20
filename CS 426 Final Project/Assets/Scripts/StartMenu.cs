using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartMenu : MonoBehaviour
{

    public GameObject controlPanel;
    public GameObject storyPanel;

    // Start is called before the first frame update
    void Start()
    {
       // controlPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void TutorialGame()
    {
        SceneManager.LoadScene("TutorialScene");
    }

    public void LoadControls()
    {
        controlPanel.SetActive(true);
    }

    public void returnFromControls()
    {
        controlPanel.SetActive(false);
    }

    public void LoadStory()
    {
        storyPanel.SetActive(true);
    }

    public void returnFromStory()
    {
        storyPanel.SetActive(false);
    }
}
