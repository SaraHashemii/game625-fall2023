using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class SpecialPelletsController : MonoBehaviour
{

    [SerializeField] private float _freezeDuration = 3f;


    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            FreezeEnemies();
        }
    }


    public void FreezeEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemyObject in enemies)
        {
            EnemyMovement enemyMovement = enemyObject.GetComponent<EnemyMovement>();

            if (enemyMovement != null)
            {
                // Freeze the enemy for the specified duration
                enemyMovement.FreezeEnemy(_freezeDuration);
            }
            else
            {
                Debug.LogWarning("EnemyMovement component not found on the enemy GameObject.");
            }
        }
    }
}





