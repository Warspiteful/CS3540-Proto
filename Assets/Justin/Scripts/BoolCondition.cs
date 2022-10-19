using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BoolCondition : Condition
{
    
    [SerializeField] private bool isCompleted;

    public override void resetCondition()
    {
        isCompleted = false;
        ValueUpdated?.Invoke();
    }
    
    public void SetFlag()
    {

        isCompleted = true;
        ValueUpdated?.Invoke();
    }

    public override bool isComplete()
    {
        return isCompleted;
    }

    public override ConditionalTasks GetType()
    {
        return ConditionalTasks.BOOL;
    }

    public override string GetRepresentation()
    {
        return isCompleted.ToString();
    }


}
