using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class IntCondition : Condition
{

    public int value;
    public int Max;
    
    public void Increment()
    {
        if (value < Max)
        {
            value += 1;
            ValueUpdated();
        }
    }
    
    public override bool isComplete()
    {
        return value == Max;
    }
    
    public override ConditionalTasks GetType()
    {
        return ConditionalTasks.INT;
    }
    
    public override string GetRepresentation()
    {
        return value.ToString() + "/" + Max.ToString();
    }
}
