using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public GameObject originalPrefab;

    [SerializeField] private Transform _target;

    [SerializeField] private LayerMask obstacleLayer;
    private NavMeshAgent _enemyAgent;

    private float _freezeDuration = 0f;
    private float _originalSpeed;

    private Vector3 _startPosition;

  
    void Start()
    {
        _enemyAgent = GetComponent<NavMeshAgent>();
        _originalSpeed = _enemyAgent.speed;
        _startPosition = transform.position;
        Debug.Log($"Stasrt position is: {_startPosition}");

    }

    void Update()
    {
        if (_freezeDuration <= 0f)
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
        else
        {
            _freezeDuration -= Time.deltaTime;

            if (_freezeDuration <= 0f)
            {

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


    public void FreezeEnemy(float duration)
    {
        _enemyAgent.speed = 0f;
        _freezeDuration = duration;
    }

    public void Respawn()
    {

        _enemyAgent.speed = 0;
        Debug.Log($"Stasrt position is: {_startPosition}");
        transform.position = _startPosition;


    }

}















