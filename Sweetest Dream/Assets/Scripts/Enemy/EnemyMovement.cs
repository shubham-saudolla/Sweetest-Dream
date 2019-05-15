using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private Transform _player;
    private NavMeshAgent _nav;

    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _nav = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        _nav.SetDestination(_player.position);
    }
}
