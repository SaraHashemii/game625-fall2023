using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : Subject
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Collectibles collectible = GetComponent<Collectibles>();
            if (collectible != null)
            {
                AddResource(collectible);
                // Optionally, you can destroy the collected object in the scene.
                Destroy(gameObject);

            }
        }

    }
}
