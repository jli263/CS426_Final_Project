using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntelManager
{
    private static IntelManager intelManager;

    private GameObject[] objects;

    private IntelManager() { }

    public static IntelManager getInstance()
    {
        if (intelManager == null)
        {
            intelManager = new IntelManager();
            intelManager.objects = GameObject.FindGameObjectsWithTag("InteractObject");
        }
        return intelManager;
    }

    public GameObject[] getObjects () {
        return objects;
    }
}
