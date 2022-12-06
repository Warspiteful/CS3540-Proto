using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BugFix : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        DebugManager.instance.enableRuntimeUI = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
