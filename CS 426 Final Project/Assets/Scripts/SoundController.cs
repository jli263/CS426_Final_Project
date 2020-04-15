using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{

    public AudioSource citySound;
    public AudioSource baseSound;
    public AudioSource houseSound;

    string currPlaying = "N/A";

    private void Update()
    {
        if (currPlaying.Equals("baseSound"))
        {
            if (!baseSound.isPlaying)
            {
                citySound.Stop();
                houseSound.Stop();
                baseSound.Play();
            }
        }
        else if (currPlaying.Equals("houseSound"))
        {
            if (!houseSound.isPlaying)
            {
                citySound.Stop();
                houseSound.Play();
                baseSound.Stop();
            }
       }
        else if (currPlaying.Equals("citySound"))
        {
            if (!citySound.isPlaying)
            {
                citySound.Play();
                houseSound.Stop();
                baseSound.Stop();
            }
        }

    }

    
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag.Equals("militaryGround"))
        {
            if (!currPlaying.Equals("baseSound"))
            {
                currPlaying = "baseSound";
            }
        }
        else if (collision.gameObject.tag.Equals("Doors"))
        {
            if (!currPlaying.Equals("houseSound"))
            {
                currPlaying = "houseSound";
            }
        }
        else if (collision.gameObject.tag.Equals("cityGround") )
        {
            if (!currPlaying.Equals("citySound"))
            {
                currPlaying = "citySound";
            }
        }
    }
}
