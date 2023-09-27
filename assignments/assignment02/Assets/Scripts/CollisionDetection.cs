using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : Observable
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Collectibles collectible = GetComponent<Collectibles>();
            if (collectible != null)
            {
                AddResource(collectible);
                Destroy(gameObject);

            }
        }

    }
}
