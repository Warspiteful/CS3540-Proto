using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskReset : MonoBehaviour
{

    [SerializeField] private List<BoolCondition> taskBools;

    void Awake()
    {
        foreach (var task in taskBools)
        {
            task.Reset();
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
