using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This system was creating using the following tutorial: https://www.youtube.com/watch?v=SGz3sbZkfkg
[CreateAssetMenu(menuName = "Inventory Item Data")]
public class InventoryItemData : ScriptableObject
{
    public string id;
    public string displayName;
    public Sprite icon;
    public GameObject prefab;
    public Condition condition;
}
