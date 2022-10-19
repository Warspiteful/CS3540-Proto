using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Remove Object")]
public class RemoveObject : ScriptableObject
{
    // TODO: Likely want to add an animation option
    public void Remove(GameObject toRemove)
    {
        toRemove.SetActive(false);
    }

    public void Use(InventoryItemData toUse)
    {
        InventorySystem.Current.Remove(toUse);
    }
}
