using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Task : ScriptableObject
{
    private bool isCompleted;

    public VariableUpdated ValueUpdated;
    
    public string Description;

    public bool IsCompleted
    {
        get
        {
            return isCompleted;
        }

        set
        {
            isCompleted = value;
            ValueUpdated();
        }
    }
}
