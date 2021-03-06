﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeMenu : MonoBehaviour
{

    public GameObject escapePanel;

    // Start is called before the first frame update
    void Start()
    {
        escapePanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1f;
    }

    public void RestartTutorial()
    {
        SceneManager.LoadScene("TutorialScene");
        Time.timeScale = 1f;
    }
}
