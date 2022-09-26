using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskListController : MonoBehaviour
{
    [SerializeField] private List<Task> TaskList;

    [SerializeField] private GameObject taskDisplay;
    private void Start()
    {
   

        foreach (Task task in TaskList)
        {
            GameObject taskItem = Instantiate(taskDisplay, this.transform);
            taskItem.GetComponent<TaskDisplay>().SetTask(task);
        }

    }
}
