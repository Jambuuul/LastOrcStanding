using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    public PlayerStatus _playerStatus;


    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerStatus = _player.GetComponent<PlayerStatus>();
        // _playerStatus.coinsCount.text = ((int)_playerStatus.Coins).ToString();
    }

    private void FixedUpdate()
    {
        float distance = Vector2.Distance(transform.position, _player.transform.position);

        if (distance < 0.15)
        {
            _playerStatus.Coins += 1;
            _playerStatus.coinsCount.text = ((int)_playerStatus.Coins).ToString();
            print("COINS = " + _playerStatus.Coins);
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
