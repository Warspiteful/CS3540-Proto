using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class CollapsableMenu : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private bool isExpanded = true;

    private int itemsCount;

    [SerializeField] private List<TaskDisplay> taskDisplays;

    [SerializeField] private Image display;

    private void Start()
    {
        isExpanded = true;
    }

    public void LoadItems(List<TaskDisplay> listOfDisplays)
    {
        
        taskDisplays.Clear();

        for (int i = 0; i < listOfDisplays.Count; i++)
        {
            taskDisplays.Add(listOfDisplays[i]);
        }
    }



    private void Update()
    {
        if (Input.GetButtonDown("Expand"))
        {
            ResetPosition();
        }

    }
    // Update is called once per frame
    public void ResetPosition()
    {
        Debug.Log("CLOSING");
        isExpanded = !isExpanded;

        if (isExpanded)
        {
            display.enabled = true;
            foreach (TaskDisplay display in taskDisplays)
            {
                display.gameObject.SetActive(true);
            }
        }
     
        if(!isExpanded)
        {
            bool isEmpty = true;
            foreach (TaskDisplay display in taskDisplays)
            {
                display.gameObject.SetActive(false);
            }
        foreach (TaskDisplay display in taskDisplays)
        {
            if (!display.observedTask.isComplete())
            {
                display.gameObject.SetActive(true);
                isEmpty = false;
                break;
            }

        
        }
        if (isEmpty)
        {
            display.enabled = false;
        }
        }

    
    }
}
