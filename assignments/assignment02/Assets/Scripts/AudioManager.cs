using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip collectSound;


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

        if (collectSound != null && audioSource != null)
        {

            audioSource.PlayOneShot(collectSound);
        }


    }
}
