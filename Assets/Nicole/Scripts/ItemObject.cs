using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public InventoryItemData referenceItem;
    
    public void OnHandlePickupItem()
    {
        InventorySystem.Current.Add(referenceItem);
        Destroy(gameObject);
    }
}
