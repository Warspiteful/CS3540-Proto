using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskDisplay : MonoBehaviour
{

    [SerializeField] public Condition observedTask;
    
    [SerializeField] private Toggle TaskFlag;
    [SerializeField] private Text IntDisplay;
    
    [SerializeField] private Text TaskDesc;

    private ConditionalTasks type;

    public void SetTask(Condition observed)
    {
        if (observedTask != null)
        {
            observedTask.ValueUpdated -= UpdateDisplay;
        }

        observedTask = observed;
        type = observedTask.GetType();
        observedTask.ValueUpdated += UpdateDisplay;
        UpdateDisplay();
    }

    private void OnDisable()
    {
        observedTask.ValueUpdated -= UpdateDisplay;

    }

    // Start is called before the first frame update
    void UpdateDisplay()
    {
        switch (type)
        {
            case ConditionalTasks.BOOL:
                TaskFlag.gameObject.SetActive(true);
                TaskFlag.isOn = observedTask.isComplete();
                break;
            case ConditionalTasks.INT:
                IntDisplay.gameObject.SetActive(true);
                IntDisplay.text = observedTask.GetRepresentation();
                if (observedTask.isComplete())
                {
                    IntDisplay.gameObject.SetActive(false);
                    TaskFlag.gameObject.SetActive(true);
                    TaskFlag.isOn = observedTask.isComplete();
                }
                break;
        }
        TaskDesc.text = observedTask.Description;
    }
}
