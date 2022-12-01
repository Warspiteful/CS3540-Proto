using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CollapsableMenu))]
public class TaskListController : MonoBehaviour
{
    [SerializeField] private List<Condition> TaskList;
    [SerializeField] private List<TaskDisplay> currentDisplays;


    [SerializeField] private TaskDisplay taskDisplay;
    
    [SerializeField] private Transform parent;

    private CollapsableMenu menu;

    private void Start()
    {
        menu = GetComponent<CollapsableMenu>();
        currentDisplays = new List<TaskDisplay>();
        UpdateDisplay();
        menu.ResetPosition();
    }

    // https://answers.unity.com/questions/611850/destroy-all-children-of-object.html
    private void UpdateDisplay()
    {
        currentDisplays.Clear();
        foreach (Transform child in parent)
        {
            Destroy(child.gameObject);
            
        }


        foreach (Condition task in TaskList)
        {
            TaskDisplay currDisplay = Instantiate(taskDisplay, parent);
            currDisplay.SetTask(task);
            currentDisplays.Add(currDisplay);
            
        }
    }

    public void AddTask(Condition task)
    {
        
        TaskList.Add(task);
        UpdateDisplay();
        menu.LoadItems(currentDisplays);
    }
}
