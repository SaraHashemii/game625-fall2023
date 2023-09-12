using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAttackController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object is an enemy
        if (other.CompareTag("Enemy"))
        {
            // Check if the enemy is frozen (has a NavMeshAgent with speed 0)
            NavMeshAgent enemyAgent = other.GetComponent<NavMeshAgent>();
            if (enemyAgent != null && enemyAgent.speed == 0f)
            {
                // Destroy the frozen enemy
                Destroy(other.gameObject);
            }
        }
    }
}
