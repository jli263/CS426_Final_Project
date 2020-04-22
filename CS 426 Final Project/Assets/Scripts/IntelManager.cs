using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntelManager
{
    
    private GameObject[] objects;

    public  IntelManager() {
        objects = GameObject.FindGameObjectsWithTag("InteractObject");
    }

    public GameObject[] getObjects () {
        return objects;
    }
}
