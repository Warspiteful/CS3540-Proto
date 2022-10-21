using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskReset : MonoBehaviour
{

    [SerializeField] private List<Condition> tasks;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Condition con in tasks)
        {
            con.resetCondition();
        }
    }

    // Update is called once per frame
    void Update()
    { 
        
    }
}
