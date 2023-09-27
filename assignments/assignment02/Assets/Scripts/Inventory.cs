using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour, IObserver
{

    private Dictionary<ItemType, int> collectiblesDictionary = new Dictionary<ItemType, int>();

    private void Start()
    {
        foreach (CollisionDetection subject in FindObjectsOfType<CollisionDetection>())
        {
            subject.AddObserver(this);
        }
    }

    public void OnCollectibleUpdated(object obj, ItemType type)
    {
        //Debug.Log("First! Line of onCollectibleUpdated");
        if (!collectiblesDictionary.ContainsKey(type))
        {
            collectiblesDictionary[type] = 1;

        }
        else
        {
            collectiblesDictionary[type]++;
        }

        Debug.Log($"Congrats! You collected {type}. Count: {collectiblesDictionary[type]}");
        // Implement your inventory logic here.

        Debug.Log("Inventory:");
        foreach (var kvp in collectiblesDictionary)
        {
            Debug.Log($"{kvp.Key}: {kvp.Value}");
        }
        //Debug.Log("Last Line of onCollectibleUpdated");
    }
}