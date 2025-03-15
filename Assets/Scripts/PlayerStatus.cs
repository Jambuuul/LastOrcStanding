using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{

    public int healthLevel = 0;
    [SerializeField] public float health = 100;
    
    [SerializeField] private Animator _animator;
    [SerializeField] private HealthManager _healthManager;
    private int _coins = 0;


    

    public Text coinsCount;


    private float _maxHealth;
    private float defaultHealth;
    private void Start()
    {
        // PlayerPrefs.SetInt("HealthLevel", 0);
        
        
        healthLevel = PlayerPrefs.GetInt("HealthLevel");
        defaultHealth = health;
        health += (health / 10) * healthLevel;
        _coins = PlayerPrefs.GetInt("PlayerCoins");
        _maxHealth = health;
        coinsCount.text = ((int)Coins).ToString();
    }

    public void UpdateHealth()
    {
        print(health);
        health = defaultHealth + (defaultHealth / 10) * healthLevel;
        _maxHealth = health;
        _healthManager.TakeDamageUI(1);
        PlayerPrefs.SetInt("HealthLevel", healthLevel);
        PlayerPrefs.Save();
    }

    public int Coins
    {
        set
        {
            PlayerPrefs.SetInt("PlayerCoins",value);
            PlayerPrefs.Save();
            _coins = value;
            coinsCount.text = ((int)Coins).ToString();
        }
        get=> _coins;
    }
    
    
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

    
    
    
    public void TakeDamage(float damage)
    {
        // print(health);
        Health -= damage;
        // if (health > 0)
        // {
        //     _animator.SetTrigger("Damaged");
        // }
        _animator.SetTrigger("Damaged");
        _healthManager.TakeDamageUI(health / _maxHealth);
        print("player " + health);
    }
    
    private void Killed()
    {
        _animator.SetTrigger("Killed");
        
    }
}
