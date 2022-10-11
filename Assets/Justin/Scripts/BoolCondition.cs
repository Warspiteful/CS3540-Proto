using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BoolCondition : Condition
{
    
    private bool isCompleted;

 

    public void SetFlag()
    {

        isCompleted = true;
        ValueUpdated();
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
