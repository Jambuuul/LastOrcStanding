using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int speedLevel = 0;
    
    public float movementSpeed = 1f;
    public float collisionOffset = 0.5f;
    public bool canMove = true;
    public float defaultMovementSpeed;
    
    private Animator _animator;
    private Vector2 _movementInput;
    private Rigidbody2D _rigidBody;
    private List<RaycastHit2D> _castCollisions = new List<RaycastHit2D>();
    private SpriteRenderer _spriteRenderer;
    
    public SwordAttack swordAttack;
    public ContactFilter2D movementFilter;

    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        // PlayerPrefs.SetInt("SpeedLevel", 0);
        // turn on when playing
        
        
        speedLevel = PlayerPrefs.GetInt("SpeedLevel");
        defaultMovementSpeed = movementSpeed;
        movementSpeed += (defaultMovementSpeed / 25) * speedLevel;
        
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        // _audioSource = GetComponent<AudioSource>();
    }

    public void UpdateSpeed()
    {
        movementSpeed = defaultMovementSpeed + (defaultMovementSpeed / 25) * speedLevel;
        PlayerPrefs.SetInt("SpeedLevel", speedLevel);
        PlayerPrefs.Save();
        
    }
    // Update is called once per frame
    private void Update()
    {
        if (!canMove) return;
        if (!TryMoving(_movementInput))
        {
            if (!TryMoving(new Vector2(_movementInput.x, 0)))
            {
                TryMoving(new Vector2(0, _movementInput.y));
            }
        }

        bool moved = _movementInput != Vector2.zero;
        
        _animator.SetBool("isMoving", moved);

        if (_movementInput.x < 0)
        {
            _spriteRenderer.flipX = true;
        }
        else if (_movementInput.x > 0)
        {
            _spriteRenderer.flipX = false;
        }
    }

    bool TryMoving(Vector2 direction)
    {
        int count = _rigidBody.Cast(
            direction,
            movementFilter,
            _castCollisions,
            movementSpeed * collisionOffset * Time.deltaTime
        );

        if (count == 0)
        {
            var tmp = direction * movementSpeed * Time.deltaTime;
            transform.position += new Vector3(tmp.x,tmp.y);
            
            // _rigidBody.MovePosition(_rigidBody.position + direction * movementSpeed * Time.deltaTime);
            return true;
        }

        return false;
    }

    

    void OnMove(InputValue movementValue)
    {
        _movementInput = movementValue.Get<Vector2>();
    }

    void OnFire()
    {
        _animator.SetTrigger("swordAttack");
    }


    public void SwordAttack()
    {
        LockMovement();
        if (_spriteRenderer.flipX)
        {
            // print("left");
            swordAttack.AttackLeft();
        }
        else
        {
            // print("right");
            swordAttack.AttackRight();
        }
    }

    private void WalkSound()
    {
        this.gameObject.GetComponent<AudioSource>().Play();
    }
    
    public void ActivateHitbox()
    {
        
        swordAttack.ActivateAttack();
    }

    public void EndAttack()
    {
        UnlockMovement();
        swordAttack.StopAttack();
    }
    
    
    void LockMovement()
    {
        canMove = false;
    }

    void UnlockMovement()
    {
        canMove = true;
    }

    public void RemoveKilled()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("SampleScene");
        
    }
}
