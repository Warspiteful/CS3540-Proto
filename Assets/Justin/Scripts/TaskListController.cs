using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskListController : MonoBehaviour
{
    [SerializeField] private List<Condition> TaskList;

    [SerializeField] private TaskDisplay taskDisplay;
    
    [SerializeField] private Transform parent;


    private void Start()
    {
        UpdateDisplay();
    }

    // https://answers.unity.com/questions/611850/destroy-all-children-of-object.html
    private void UpdateDisplay()
    {
        foreach (Transform child in parent)
        {
            Destroy(child.gameObject);
        }


        foreach (Condition task in TaskList)
        {
          Instantiate(taskDisplay, parent).SetTask(task);
        }
    }

    public void AddTask(Condition task)
    {
        
        TaskList.Add(task);
        UpdateDisplay();
    }
}
