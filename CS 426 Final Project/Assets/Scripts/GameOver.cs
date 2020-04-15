using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameoverPanel;

   
   

    // Start is called before the first frame update
    void Start()
    {
        gameoverPanel.SetActive(false);
    }

    public void Update()
    {
       
    }

    public void gameOver()
    {
        gameoverPanel.SetActive(true);
        Time.timeScale = 0f;
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
}
