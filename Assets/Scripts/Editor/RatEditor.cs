using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(RatController))]
public class RatEditor : Editor
{
    // Start is called before the first frame update


       public override void OnInspectorGUI()
       {
           RatController myScript = (RatController)target;
                if (GUILayout.Button("Kill Rat"))
                {
                   
                   myScript.WasSpotted();
                }
       }
}
