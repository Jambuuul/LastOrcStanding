using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGate : MonoBehaviour
{
    [SerializeField] private Enemy[] _blockingEnemies;

    private int _counter;
    // Start is called before the first frame update
    void Start()
    {
        _counter = _blockingEnemies.Length;
        foreach (var enemy in _blockingEnemies)
        {
            enemy.EnemyKilled += DecreaseCount;
        }
    }

    void DecreaseCount()
    {
        _counter--;
        if (_counter == 0)
        {
            foreach (var enemy in _blockingEnemies)
            {
                enemy.EnemyKilled -= DecreaseCount;
            }
            Destroy(gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
