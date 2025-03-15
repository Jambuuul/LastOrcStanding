using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapActivation : MonoBehaviour
{
    [SerializeField] private PlayerStatus _player;
    [SerializeField] private Animator _animator;
    [SerializeField] private float damage = 50;

    [SerializeField] private float side1, side2;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            _animator.SetTrigger("Activated");
        }
    }
    
    // private void OnDrawGizmos()
    // {
    //     Gizmos.DrawWireCube(transform.position,new Vector3(side1,side2,0));
    // }

    private void CheckPlayer()
    {
        Collider2D[] cols = Physics2D.OverlapBoxAll(transform.position, new Vector2(side1, side2), 0);
        
        foreach(var t in cols)
        {
            if (t.CompareTag("Player") && !t.isTrigger)
            {
                _player = t.GetComponent<PlayerStatus>();
                _player.TakeDamage(damage);
            }
        }
    }
}
