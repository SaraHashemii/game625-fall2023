using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI inventoryText;

    private void OnEnable()
    {
        Inventory.OnInventoryUpdated += UpdateInventoryUI;
    }
    private void OnDisable()
    {
        Inventory.OnInventoryUpdated -= UpdateInventoryUI;
    }

    private void UpdateInventoryUI(Dictionary<ItemType, int> inventoryContent)
    {

        inventoryText.text = "\n";

        foreach (var kvp in inventoryContent)
        {
            inventoryText.text += $"{kvp.Key}: {kvp.Value}\n";

        }
    }


}

