using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntelCollected : MonoBehaviour
{
    public Text intelText;
    public int maxScore = 4;

    int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        intelText.text = "Number of Intel Collected: " + score + "/4";
    }

    // Update is called once per frame
    public void AddPoint()
    {
        score++;
        if(score != maxScore)
            intelText.text = "Number of Intel Collected: " + score + "/4";
    }
}
