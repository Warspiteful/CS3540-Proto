using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(IntCondition))]
public class IntVariableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        IntCondition myTarget = (IntCondition)target;

        myTarget.value = EditorGUILayout.IntField("Value", myTarget.value);
        myTarget.Max = EditorGUILayout.IntField("Max", myTarget.Max);
        if(GUILayout.Button("Incrmenet"))
        {
            myTarget.Increment();
        }


    }
}
