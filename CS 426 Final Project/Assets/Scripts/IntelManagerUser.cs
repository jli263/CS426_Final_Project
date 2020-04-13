using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntelManagerUser : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        IntelManager.getInstance();
        Debug.Log(IntelManager.getInstance().getObjects().Length);
    }

}
