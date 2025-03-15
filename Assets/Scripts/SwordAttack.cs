using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Assertions.Must;

public class SwordAttack : MonoBehaviour
{
    public int damageLevel = 0;
    [SerializeField] private float damage = 50;
    private float defaultDamage;

    
    private Vector2 _rightAttackOffset;
    public Collider2D swordCollider;
    void Start()
    {
        // PlayerPrefs.SetInt("DamageLevel", 0);
        
        // turn off when playing
        
        damageLevel = PlayerPrefs.GetInt("DamageLevel");
        defaultDamage = damage;
        damage += damage * damageLevel;
        _rightAttackOffset = transform.position;
        
    }

    public void UpdateDamage()
    {
        damage = defaultDamage + (defaultDamage / 10) * damageLevel;
        PlayerPrefs.SetInt("DamageLevel", damageLevel);
        PlayerPrefs.Save();
    }
    
    public void AttackRight()
    {
        
        transform.localPosition = _rightAttackOffset;
    }

    public void AttackLeft()
    {
  
        transform.localPosition = new Vector3(_rightAttackOffset.x * -1, _rightAttackOffset.y);
    }

    public void StopAttack()
    {
        swordCollider.enabled = false;
    }

    public void ActivateAttack()
    {
        swordCollider.enabled = true;
    } 

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.tag != "Enemy") return;

        
        //GameObject obj = GameObject.FindWithTag("Enemy");
        Enemy enemy = other.GetComponent<Enemy>();
        
        if (enemy == null) return;
        
        enemy.TakeDamage(damage);

    }
}
