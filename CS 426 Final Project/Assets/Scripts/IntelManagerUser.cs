using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntelManagerUser : MonoBehaviour
{
    static public IntelManager intelManager;
    // Start is called before the first frame update
    void Start()
    {
        intelManager = new IntelManager();
        Debug.Log(intelManager.getObjects().Length);
    }

}
