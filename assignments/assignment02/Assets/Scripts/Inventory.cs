using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour, IObserver
{
    public static event Action<Dictionary<ItemType, int>> OnInventoryUpdated;

    private Dictionary<ItemType, int> collectiblesDictionary = new Dictionary<ItemType, int>();

    private void OnEnable()
    {
        foreach (CollisionDetection subject in FindObjectsOfType<CollisionDetection>())
        {
            subject.AddObserver(this);
        }
    }
    private void OnDisable()
    {

        foreach (CollisionDetection subject in FindObjectsOfType<CollisionDetection>())
        {
            subject.RemoveObserver(this);
        }
    }

    public void OnCollectibleUpdated(object obj, ItemType type)
    {
        ////Debug.Log("First! Line of onCollectibleUpdated");
        if (!collectiblesDictionary.ContainsKey(type))
        {
            collectiblesDictionary[type] = 1;

        }
        else
        {
            collectiblesDictionary[type]++;
        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        if (OnInventoryUpdated != null)
        {
            OnInventoryUpdated(collectiblesDictionary);
        }
    }
}