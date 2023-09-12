using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class SpecialPelletsController : MonoBehaviour
{
    //[SerializeField] private float freezeDuration = 3f;


    //private void OnTriggerEnter(Collider collider)
    //{
    //    if (collider.gameObject.CompareTag("Player"))
    //    {
    //        Destroy(gameObject);
    //        FreezeEnemies();
    //    }
    //}

    //private void FreezeEnemies()
    //{
    //    GameObject[] enemies;
    //    enemies = GameObject.FindGameObjectsWithTag("Enemy");

    //    foreach (GameObject enemyObject in enemies)
    //    {
    //        NavMeshAgent navMeshAgent = enemyObject.GetComponent<NavMeshAgent>();
    //        if (navMeshAgent != null)
    //        {
    //            // Store the original speed of the NavMesh Agent
    //            float originalSpeed = navMeshAgent.speed;

    //            // Freeze the NavMesh Agent by setting its speed to 0
    //            navMeshAgent.speed = 0f;

    //            // Start the unfreeze timer
    //            StartCoroutine(UnfreezeNavMeshAgent(navMeshAgent, originalSpeed));
    //        }
    //    }
    //}

    //// Coroutine to unfreeze the NavMesh Agent after a specified duration
    //private IEnumerator UnfreezeNavMeshAgent(NavMeshAgent navMeshAgent, float originalSpeed)
    //{
    //    Debug.Log("before");
    //    yield return new WaitForSeconds(freezeDuration);
    //    Debug.Log("after ");
    //    // Unfreeze the NavMesh Agent by restoring its speed to the original value
    //    navMeshAgent.speed = originalSpeed;
    //}


    [SerializeField] private float freezeDuration = 3f;


    private Dictionary<NavMeshAgent, float> frozenAgents = new Dictionary<NavMeshAgent, float>();

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            FreezeEnemies();
        }
    }



    private void FreezeEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemyObject in enemies)
        {
            EnemyMovement enemyMovement = enemyObject.GetComponent<EnemyMovement>();

            if (enemyMovement != null)
            {
                // Freeze the enemy for the specified duration
                enemyMovement.FreezeEnemy(freezeDuration);
            }
            else
            {
                Debug.LogWarning("EnemyMovement component not found on the enemy GameObject.");
            }
        }
    }
}





