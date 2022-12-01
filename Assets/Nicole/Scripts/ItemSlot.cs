using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private Image m_icon;
    [SerializeField] private TextMeshProUGUI m_label;
    [SerializeField] private GameObject m_stackObj;
    [SerializeField] private TextMeshProUGUI m_stackLabel;

    public void Awake()
    {
        m_icon = gameObject.transform.Find("Icon").gameObject.GetComponent<Image>();
        m_label = gameObject.transform.Find("Label").gameObject.GetComponent<TextMeshProUGUI>();
        m_stackObj = gameObject.transform.Find("Stack Box").gameObject;
        m_stackLabel = m_stackObj.transform.Find("Number").gameObject.GetComponent<TextMeshProUGUI>();
    }

    public void Set(InventorySystem.InventoryItem item)
    {
        Debug.Log("item: " + item);
        m_icon.sprite = item.data.icon;
        m_label.text = item.data.displayName;
        if (item.stackSize <= 1)
        {
            m_stackObj.SetActive(false);
            return;
        }
        // Debug.Log(m_stackLabel);
        m_stackLabel.text = item.stackSize.ToString();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        // m_icon = gameObject.GetComponent<Image>();
        // m_label = gameObject.GetComponent<TextMeshProUGUI>();
        // m_stackObj = gameObject.transform.GetChild(0).gameObject;
        // m_stackLabel = m_stackObj.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}