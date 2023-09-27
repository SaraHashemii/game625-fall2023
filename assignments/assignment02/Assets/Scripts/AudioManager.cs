using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] AudioSource audioSource;


    private void OnEnable()
    {

        Inventory.OnInventoryUpdated += PlayCollectSound;
    }

    private void OnDisable()
    {

        Inventory.OnInventoryUpdated -= PlayCollectSound;
    }

    private void PlayCollectSound(Dictionary<ItemType, int> inventoryContent)
    {

        if (audioSource != null)
        {

            audioSource.Play();
        }


    }
}
