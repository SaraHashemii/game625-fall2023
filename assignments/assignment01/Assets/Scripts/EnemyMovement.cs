using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform _target;

    [SerializeField] private LayerMask obstacleLayer;
    private NavMeshAgent _enemyAgent;

    private float _freezeDuration = 0f; 

    private float _originalSpeed;

    void Start()
    {
        _enemyAgent = GetComponent<NavMeshAgent>();
        _originalSpeed = _enemyAgent.speed;
    }

    void Update()
    {
        //if (_target != null)
        //{
        //    _enemyAgent.SetDestination(_target.position);
        //}


        //if (IsEnemyInPath())
        //{

        //    Vector3 newDestination = _target.position + Random.insideUnitSphere * 10f;
        //    _enemyAgent.SetDestination(newDestination);
        //}
        if (_freezeDuration <= 0f) // Check if not frozen
        {
            if (_target != null)
            {
                _enemyAgent.SetDestination(_target.position);
            }

            if (IsEnemyInPath())
            {
                Vector3 newDestination = _target.position + Random.insideUnitSphere * 10f;
                _enemyAgent.SetDestination(newDestination);
            }
        }
        else // If frozen, decrement the freeze duration
        {
            _freezeDuration -= Time.deltaTime;

            if (_freezeDuration <= 0f)
            {
                // Unfreeze the agent by restoring its speed to the original value
                _enemyAgent.speed = _originalSpeed;
            }
        }

    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    bool IsEnemyInPath()
    {

        RaycastHit hit;
        if (Physics.Raycast(transform.position, _enemyAgent.velocity.normalized, out hit, 10f, obstacleLayer))
        {
            if (hit.collider.CompareTag("Enemy") && hit.collider.gameObject != gameObject)
            {
                return true;
            }
        }
        return false;
    }

    // Function to freeze the enemy
    public void FreezeEnemy(float duration)
    {
        _enemyAgent.speed = 0f;
        _freezeDuration = duration;
    }
}

















