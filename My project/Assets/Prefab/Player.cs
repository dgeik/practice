using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor.Rendering.Universal;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : Entity
{
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private Image _hpBar;
    private readonly float _moveSpeed = 10f;
    private Rigidbody2D _rigidbody;
    private GameObject _nearestEnemy = null;
    public GameObject getNearestEnemy { get { return _nearestEnemy; } }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _hpBar.fillAmount = PlayerData.hp / PlayerData.maxHp;
    }

    private void FixedUpdate()
    {
        _rigidbody.linearVelocity = new Vector2(_joystick.Horizontal * _moveSpeed, _joystick.Vertical * _moveSpeed);
        
    }
    private void Update()
    {
        _nearestEnemy = FindNearestEnemy();
        if (Keyboard.current.f5Key.isPressed)
        {
            SaveLoadManager.SaveGame();
        }

        if (Keyboard.current.f6Key.isPressed)
        {
            SaveLoadManager.LoadGame();
        }
    }

    public override void TakeDamage(float damage)
    {
        PlayerData.hp -= damage;
        _hpBar.fillAmount = PlayerData.hp / PlayerData.maxHp;
        if (PlayerData.hp <= 0f)
        {
            gameObject.SetActive(false);
            Debug.Log("Dead");
        }
    }

    private GameObject FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nearestEnemy = null;
        float distance = Mathf.Infinity;
        Vector2 position = transform.position;
        foreach (GameObject enemy in enemies)
        {
            Vector2 difference = (Vector2)enemy.transform.position - position;
            if (difference.sqrMagnitude < distance && difference.sqrMagnitude <= transform.GetComponentInChildren<CircleCollider2D>().radius)
            {
                nearestEnemy = enemy;
                distance = difference.sqrMagnitude;
            }
        }
        return nearestEnemy;
    }
}
