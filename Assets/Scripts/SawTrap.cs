using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawTrap : MonoBehaviour
{
    [SerializeField] private PlayerStatus _player;
    [SerializeField] private Animator _animator;
    [SerializeField] private float damage = 50;

    [SerializeField] private float side1, side2;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            _player.TakeDamage(damage);
        }
    }
    
}