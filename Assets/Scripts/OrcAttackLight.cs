using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OrcAttackLight : MonoBehaviour
{
    [SerializeField] private float damage = 50;
    private Vector2 _rightAttackOffset;
    public Collider2D orcCollider;
    private ContactFilter2D _filter;
    private PlayerController _player;
    private PlayerStatus _playerStatus;
    void Start()
    {
        _rightAttackOffset = transform.localPosition;
        _player = GetComponent<PlayerController>();
        // _playerStatus = GetComponent<PlayerStatus>();
    }

    


    public float side1 = 0.1f, side2 = 0.2f;
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(orcCollider.transform.position,new Vector3(side1,side2,0));
    }
    
    public void AttackRight()
    {
        transform.localPosition = _rightAttackOffset;
    }

    public void AttackLeft()
    {
        transform.localPosition = new Vector3(_rightAttackOffset.x * -1, _rightAttackOffset.y);
    }
    
    

    public void CheckEnemy()
    {
        Collider2D[] cols = Physics2D.OverlapBoxAll(orcCollider.transform.position, new Vector2(side1, side2), 0);
        foreach(var t in cols)
        {
            if (t.CompareTag("Player") && t.isTrigger)
            {
                _playerStatus = t.GetComponent<PlayerStatus>();
                if (_playerStatus == null)
                {
                    // print("null");
                    return;
                }
                // print("works!!! ");
                
                _playerStatus.TakeDamage(damage);
            }
        }
    }
   
    // public void StopAttack()
    // {
    //     orcCollider.enabled = false;
    // }
    //
    // public void ActivateAttack()
    // {
    //     orcCollider.enabled = true;
    // } 

    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     //if (other.tag != "Enemy") return;
    //     
    //     
    //     //GameObject obj = GameObject.FindWithTag("Enemy");
    //     PlayerStatus enemy = other.GetComponent<PlayerStatus>();
    //     
    //     if (enemy == null) return;
    //     
    //     enemy.TakeDamage(damage);
    //     
    // }
    
    
}

