using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskDisplay : MonoBehaviour
{

    [SerializeField] public Task observedTask;
    
    [SerializeField] private Toggle TaskFlag;
    
    [SerializeField] private Text TaskDesc;

    public void SetTask(Task observed)
    {
        if (observedTask != null)
        {
            observedTask.ValueUpdated -= UpdateDisplay;
        }
        observedTask = observed;
        observedTask.ValueUpdated += UpdateDisplay;
        UpdateDisplay();
    }

    // Start is called before the first frame update
    void UpdateDisplay()
    {
        TaskFlag.isOn = observedTask.IsCompleted;
        TaskDesc.text = observedTask.Description;
    }
}
