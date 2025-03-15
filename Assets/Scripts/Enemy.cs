using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   [SerializeField] private Animator _animator;

    private bool canMove = true;
    public GameObject _player;
    [SerializeField] private float enemySpeed = 2;
    public Rigidbody2D rb;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] OrcAttackLight orcAttackLight;
    [SerializeField] private GameObject _coinPrefab;

    public event Action EnemyKilled;

    private void Start()
    {
        // _animator = GetComponent<Animator>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        float distance = Vector2.Distance(transform.position, _player.transform.position);
        
        Vector2 direction = _player.transform.position - transform.position;
        // direction.Normalize();
        
        if (!canMove) return;
        
        if (distance < 1)
        {
            rb.MovePosition(rb.position + direction * enemySpeed * Time.fixedDeltaTime);
            _animator.SetBool("isMoving", true);
            // print("true");
        }
        else
        {
            _animator.SetBool("isMoving", false);
        }

        if (distance < 0.4)
        {
            _animator.SetTrigger("attackStarted");
        }
        // else
        // {
        //     direction = Vector2.zero;
        // }

        // bool moved = direction != Vector2.zero;
        // if (distance >= 0.4)
        // {
        //     moved = false;
        // }
        // _animator.SetBool("isMoving", moved);
        
        if (direction.x < 0)
        {
            _spriteRenderer.flipX = true;
        }
        else if (direction.x > 0)
        {
            _spriteRenderer.flipX = false;
        }
        
        
        
    }

    public void OrcAttackLight()
    {
        LockMovement();
        if (_spriteRenderer.flipX)
        {
            // print("left");
            orcAttackLight.AttackLeft();
        }
        else
        {
            // print("right");
            orcAttackLight.AttackRight();
        }
    }
    
    
    
    public void ActivateHitbox()
    {
        orcAttackLight.CheckEnemy();
    }
    //
    // public void EndAttack()
    // {
    //     UnlockMovement();
    //     orcAttackLight.StopAttack();
    // }

    
    public float Health
    {
        set
        {
            health = value;
            if (health <= 0)
            {
                Killed();
            }
        }
        get => health;
    }
    
    [SerializeField] private float health = 10;


    public void Attacked(float damage)
    {
        
    }
    public void TakeDamage(float damage)
    {
        // print(health);
        Health -= damage;
        if (health > 0)
        {
            _animator.SetTrigger("Damaged");
            
        }
        print(health);
    }

    private void Killed()
    {
        _animator.SetTrigger("Killed");
        EnemyKilled?.Invoke();
    }

    public void RemoveKilled()
    {
        Destroy(gameObject);
        Instantiate(_coinPrefab, transform.position, Quaternion.identity);
    }
    
    void LockMovement()
    {
        canMove = false;
    }

    void UnlockMovement()
    {
        canMove = true;
    }
}
