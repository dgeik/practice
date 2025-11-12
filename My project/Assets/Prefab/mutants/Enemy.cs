using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class Enemy : Entity
{
    [SerializeField] private float _hp;
    [SerializeField] private float _damage;
    [SerializeField] private Image _hpBar;
    [SerializeField] private List<GameObject> _itemsToSpawn = new List<GameObject>();
    private float _maxHp;
    private GameObject _player;
    private NavMeshAgent _agent;
    private float _delayBeforeAttack;
    private readonly float _maxDelayBeforeAttack = 2f;
    public bool isAttack;

    public States state = States.Idle;
    public enum States
    {
        Idle,
        Attack,
        Chase
    }
    private void Awake()
    {
        _maxHp = _hp;
        _hpBar.fillAmount = _hp / _maxHp;
        _player = GameObject.FindWithTag("Player");
        _delayBeforeAttack = _maxDelayBeforeAttack;
    }
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }
    private void Update()
    {
        CheckState();
    }
    private void CheckState()
    {
        switch (state)
        {
            default:
            case States.Attack:
                AttackPlayer();
                break;
            case States.Chase:
                MoveToPlayer();
                break;
            case States.Idle:
                break;
        }
    }
    public void MoveToPlayer()
    {
        _delayBeforeAttack = _maxDelayBeforeAttack;
        _agent.SetDestination(_player.GetComponent<Transform>().position);
    }
    public void AttackPlayer()
    {
        _delayBeforeAttack -= Time.deltaTime;
        if (_delayBeforeAttack <= 0f)
        {
            _player.GetComponent<Player>().TakeDamage(_damage);
            _delayBeforeAttack = _maxDelayBeforeAttack;
        }
    }
    public override void TakeDamage(float damage)
    {
        _hp -= damage;
        _hpBar.fillAmount = _hp / _maxHp;
        if (_hp <= 0f)
        {
            if (_itemsToSpawn != null)
            {
                int randomItemInex = Random.Range(0, _itemsToSpawn.Count);
                Instantiate(_itemsToSpawn[randomItemInex], gameObject.transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
