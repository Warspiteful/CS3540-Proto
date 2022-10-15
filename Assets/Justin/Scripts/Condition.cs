using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Condition : ScriptableObject
{
    public VariableUpdated ValueUpdated;
    
    public string Description;
    public abstract bool isComplete();

    public abstract ConditionalTasks GetType();

    public abstract string GetRepresentation();

    public abstract void resetCondition();
}
