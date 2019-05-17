using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamageMin;
    public int attackDamageMax;

    private Animator _anim;
    private GameObject _player;
    private PlayerHealth _playerHealth;
    private EnemyHealth _enemyHealth;
    private bool _playerInRange;
    private float _timer;
    private int _attackDamage;

    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerHealth = _player.GetComponent<PlayerHealth>();
        _enemyHealth = GetComponent<EnemyHealth>();
        _anim = GetComponent<Animator>();
        _attackDamage = Random.Range(attackDamageMin, attackDamageMax);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player)
        {
            _playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _playerInRange = false;
    }

    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= timeBetweenAttacks && _playerInRange && _enemyHealth.currentHealth > 0)
        {
            Attack();
        }
        if (_playerHealth.currentHealth <= 0)
        {
            _anim.SetTrigger("PlayerDead");
        }
    }

    void Attack()
    {
        _timer = 0f;

        if (_playerHealth.currentHealth > 0)
        {
            _playerHealth.TakeDamage(_attackDamage);
        }
    }
}
