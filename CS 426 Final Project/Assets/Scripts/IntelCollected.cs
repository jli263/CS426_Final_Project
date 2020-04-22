using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntelCollected : MonoBehaviour
{
    public Text intelText;
    public int maxScore = 6;
    public bool isTutorial = false;

    public static int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        if (isTutorial)
        {
            intelText.text = "Number of Intel Collected: " + score + "/2";
        }
        else
        {
            intelText.text = "Number of Intel Collected: " + score + "/6";
        }
        
    }

    // Update is called once per frame
    public void AddPoint()
    {
        score++;
        if (score < maxScore + 1)
        {
            if (isTutorial)
            {
                intelText.text = "Number of Intel Collected: " + score + "/2";
            }
            else
            {
                intelText.text = "Number of Intel Collected: " + score + "/6";
            }
        }
    }

    public void SubtractPoint()
    {
        score--;
        //if (score < maxScore + 1)
        if (isTutorial)
        {
            intelText.text = "Number of Intel Collected: " + score + "/2";
        }
        else
        {
            intelText.text = "Number of Intel Collected: " + score + "/6";
        }
    }
}
