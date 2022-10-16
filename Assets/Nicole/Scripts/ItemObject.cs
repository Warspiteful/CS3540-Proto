using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public InventoryItemData referenceItem;
    private InventorySystem inventorySystem;

    public void Awake()
    {
        inventorySystem = GetComponent<InventorySystem>();
    }

    public void OnHandlePickupItem()
    {
        inventorySystem.Add(referenceItem);
        Destroy(gameObject);
    }
}
