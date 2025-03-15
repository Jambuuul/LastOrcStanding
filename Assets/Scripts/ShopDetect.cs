using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShopDetect : MonoBehaviour
{

    [SerializeField] private GameObject _shopPanel;

    [SerializeField] private GameObject _player;
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        float distance = Vector2.Distance(transform.position, _player.transform.position);
        
        _shopPanel.SetActive(distance < 0.18);
    }
}
