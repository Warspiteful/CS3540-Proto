using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem
{

    private Dictionary<InventoryItemData, InventoryItem> m_itemDictionary;
    public List<InventoryItem> inventory { get; private set; }
    private static InventorySystem _instance;

    // Eventing for UI
    public delegate void OnInventoryChangeEventDelegate();
    public event OnInventoryChangeEventDelegate OnInventoryChangeEvent;

    // Implementing the Singleton pattern
    public static InventorySystem Current
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("Inventory system is null");
                _instance = new InventorySystem();
            }
    
            return _instance;
        }
    }

    public InventorySystem()
    {
        inventory = new List<InventoryItem>();
        m_itemDictionary = new Dictionary<InventoryItemData, InventoryItem>();
        _instance = this;
    }

    public void Add(InventoryItemData referenceData)
    {
        if (m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.AddToStack();
        }
        else
        {
            InventoryItem newItem = new InventoryItem(referenceData);
            inventory.Add(newItem);
            m_itemDictionary.Add(referenceData, newItem);

            if (referenceData.condition != null)
            {
                switch (referenceData.condition.GetType())
                {
                    case ConditionalTasks.BOOL:
                        ((BoolCondition) referenceData.condition).SetFlag();
                        break;
                }
            }
        }

        OnInventoryChangeEvent?.Invoke();
    }

    public void Remove(InventoryItemData referenceData)
    {
        if (m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.RemoveFromStack();

            if (value.stackSize == 0)
            {
                inventory.Remove(value);
                m_itemDictionary.Remove(referenceData);
            }
        }

        OnInventoryChangeEvent?.Invoke();
    }

    public void Reset()
    {
        _instance = new InventorySystem();
    }
    
    [Serializable]
    public class InventoryItem
    {
        public InventoryItemData data { get; private set; }
        public int stackSize { get; private set; }

        public InventoryItem(InventoryItemData source)
        {
            data = source;
            AddToStack();
        }

        public void AddToStack()
        {
            stackSize++;
        }

        public void RemoveFromStack()
        {
            stackSize--;
        }
        
        public override string ToString()
        {
            return data + ": " + stackSize;
        }
    }
}
