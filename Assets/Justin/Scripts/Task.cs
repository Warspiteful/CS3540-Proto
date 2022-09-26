using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : ScriptableObject
{
    public bool isCompleted;
    
    [SerializeField] private string Description;
}
