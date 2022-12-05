using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject slotPrefab;
    public GameObject bar;

    public void Awake()
    {
        OnUpdateInventory();
        InventorySystem.Current.OnInventoryChangeEvent += OnUpdateInventory;
        DontDestroyOnLoad(this.gameObject);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        // InventorySystem.Current.OnInventoryChangeEvent += OnUpdateInventory;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnUpdateInventory()
    {
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }

        DrawInventory();
    }

    public void DrawInventory()
    {
        if (InventorySystem.Current.inventory.Count <= 0)
        {
            bar.SetActive(false);
        }
        else
        {
            bar.SetActive(true);
        }
        
        foreach (InventorySystem.InventoryItem item in InventorySystem.Current.inventory)
        {
            AddInventorySlot(item);
        }
    }

    public void AddInventorySlot(InventorySystem.InventoryItem item)
    {
        GameObject obj = Instantiate(slotPrefab);
        obj.transform.SetParent(transform, false);
        ItemSlot slot = obj.GetComponent<ItemSlot>();
        slot.Set(item);
    }
}
