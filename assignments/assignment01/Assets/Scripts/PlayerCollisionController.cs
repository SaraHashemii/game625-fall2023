using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerCollisionController : MonoBehaviour
{

    [Header("Health")]
    private int _maxHealth = 3;
    private static int _currentHealth;

    public static int GetcurrentHealth() { return _currentHealth; }
    public static void SetcurrentHealth(int value) { _currentHealth = value; }

    private static bool _isGameOver = false;
    public static bool GetIsGameOver() { return _isGameOver; }

  

    private void Start()
    {
        _currentHealth = _maxHealth;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object is an enemy
        if (other.CompareTag("Enemy"))
        {
            // Check if the enemy is frozen (has a NavMeshAgent with speed 0)
            NavMeshAgent enemyAgent = other.GetComponent<NavMeshAgent>();
            if (enemyAgent != null && enemyAgent.speed == 0f)
            {
                EnemyMovement enemyMovement = other.GetComponent<EnemyMovement>();
                if (enemyMovement != null)
                {
                    enemyMovement.Respawn();
                }

            }
            else
            {
                _currentHealth--;
               

                if (_currentHealth <= 0)
                {
                    _isGameOver = true;
                }
            }
        }
    }

}
