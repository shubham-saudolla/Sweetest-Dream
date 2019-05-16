﻿using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private Transform _player;
    private NavMeshAgent _nav;
    private PlayerHealth _playerHealth;
    private EnemyHealth _enemyHealth;

    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _nav = GetComponent<NavMeshAgent>();
        _playerHealth = _player.GetComponent<PlayerHealth>();
        _enemyHealth = GetComponent<EnemyHealth>();
    }

    void Update()
    {
        if (_enemyHealth.currentHealth > 0 && _playerHealth.currentHealth > 0)
            _nav.SetDestination(_player.position);
        else
        {
            _nav.enabled = false;
        }
    }
}
