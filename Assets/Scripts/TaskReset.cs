using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskReset : MonoBehaviour
{

    [SerializeField] private List<Condition> tasks;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (Condition con in tasks)
        {
            Debug.Log("RESET" + con.name);
            con.resetCondition();
        }
    }

    // Update is called once per frame
    void Update()
    { 
        
    }
}
