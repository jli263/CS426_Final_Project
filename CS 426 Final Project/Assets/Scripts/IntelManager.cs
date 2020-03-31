using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntelManager
{
    private static IntelManager intelManager;

    private GameObject[] intels;

    private IntelManager() { }

    public static IntelManager getInstance()
    {
        if (intelManager == null)
        {
            intelManager = new IntelManager();
            intelManager.intels = GameObject.FindGameObjectsWithTag("Intel");
        }
        return intelManager;
    }

    public GameObject[] getIntels () {
        return intels;
    }
}
