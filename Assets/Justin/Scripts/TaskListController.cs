using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskListController : MonoBehaviour
{
    [SerializeField] private List<Condition> TaskList;

    [SerializeField] private GameObject taskDisplay;

    private void Start()
    {
        UpdateDisplay();
    }

    // https://answers.unity.com/questions/611850/destroy-all-children-of-object.html
    private void UpdateDisplay()
    {
        foreach (Transform child in this.transform)
        {
            GameObject.Destroy(child.gameObject);
        }


        foreach (Condition task in TaskList)
        {
            GameObject taskItem = Instantiate(taskDisplay, this.transform);
            taskItem.GetComponent<TaskDisplay>().SetTask(task);
        }
    }

    public void AddTask(Condition task)
    {
        TaskList.Add(task);
        UpdateDisplay();
    }
}
