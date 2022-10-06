using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolVariable : ScriptableObject
{
    public VariableUpdated valueUpdated;
    private bool value;
    
    public bool Value{
        get {
            return value;
        }
        set {
            value = Value;
            valueUpdated();
        }
    }
    
}
