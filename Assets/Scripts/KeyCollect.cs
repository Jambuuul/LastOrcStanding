using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class KeyCollect : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    public PlayerStatus _playerStatus;


    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        // _playerStatus.coinsCount.text = ((int)_playerStatus.Coins).ToString();
    }

    private void FixedUpdate()
    {
        float distance = Vector2.Distance(transform.position, _player.transform.position);

        if (distance < 0.15)
        {
            Destroy(gameObject);
        }
    }

    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     _playerStatus.Coins += 1;
    //     print("COIN!!!");
    //     Destroy(gameObject);
    // }
}