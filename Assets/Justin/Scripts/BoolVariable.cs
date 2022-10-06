using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BoolVariable : ScriptableObject
{
    public VariableUpdated valueUpdated;
    [SerializeField] private bool value;
    
    public bool Value{
        get {
            return value;
        }
        set {
            this.value = value;
            valueUpdated();
        }
    }
    
}
