using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{

    [SerializeField] private PlayerStatus _playerStatus;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private SwordAttack _swordAttack;
    [SerializeField] private Text dmgLevel;
    [SerializeField] private Text spdLevel;
    [SerializeField] private Text hpLevel;
    
    [SerializeField] private Text dmgPrice;
    [SerializeField] private Text spdPrice;
    [SerializeField] private Text hpPrice;
    
    [SerializeField] private Button hpButton;
    [SerializeField] private Button dmgButton;
    [SerializeField] private Button spdButton;
    
    
    // Start is called before the first frame update
    void Start()
    {
        // _playerStatus = GetComponent<PlayerStatus>();
        // _playerController = GetComponent<PlayerController>();
        // _swordAttack = GetComponent<SwordAttack>();
        hpButton.image.color = Color.green;
        dmgButton.image.color = Color.green;
        spdButton.image.color = Color.green;
    }

    // Update is called once per frame

    private int GetPrice(int level)
    {
        if (level == 0)
        {
            return 1;
        }
        return Mathf.RoundToInt((float)level * Mathf.Pow(1.1f, level));
    }
    
    public void BuyUpgrade(int intType)
    {
        UpgradeType type = (UpgradeType)intType;
        int level, price;

        switch (type)
        {
            case UpgradeType.Health:
                level = _playerStatus.healthLevel;
                price = GetPrice(level);
                if (price <= _playerStatus.Coins)
                {
                    _playerStatus.healthLevel += 1;
                    _playerStatus.Coins -= price;
                    _playerStatus.UpdateHealth();
                    hpButton.image.color = Color.green;
                    if (GetPrice(level + 1) > _playerStatus.Coins)
                    {
                        hpButton.image.color = Color.red;
                    }
                }
                else
                {
                    hpButton.image.color = Color.red;
                }
                hpLevel.text = $"Level {_playerStatus.healthLevel}";
                hpPrice.text = $"{GetPrice(_playerStatus.healthLevel)}";
                
                break;
            case UpgradeType.Damage:
                level = _swordAttack.damageLevel;
                price = GetPrice(level);
                if (price <= _playerStatus.Coins)
                {
                    _swordAttack.damageLevel += 1;
                    _playerStatus.Coins -= price;
                    _swordAttack.UpdateDamage();
                    dmgButton.image.color = Color.green;
                    if (GetPrice(level + 1) > _playerStatus.Coins)
                    {
                        dmgButton.image.color = Color.red;
                    }
                }
                else
                {
                    dmgButton.image.color = Color.red;
                }
                dmgLevel.text = $"Level {_swordAttack.damageLevel}";
                dmgPrice.text = $"{GetPrice(_swordAttack.damageLevel)}";
                break;
            case UpgradeType.Speed:
                level = _playerController.speedLevel;
                price = GetPrice(level);
                print(price);
                if (price <= _playerStatus.Coins)
                {
                    _playerController.speedLevel += 1;
                    _playerStatus.Coins -= price;
                    _playerController.UpdateSpeed();
                    spdButton.image.color = Color.green;
                    if (GetPrice(level + 1) > _playerStatus.Coins)
                    {
                        spdButton.image.color = Color.red;
                    }
                }
                else
                {
                    spdButton.image.color = Color.red;
                }
                spdLevel.text = $"Level {_playerController.speedLevel}";
                spdPrice.text = $"{GetPrice(_playerController.speedLevel)}";
                break;
        }
        
    }
}

enum UpgradeType
{
    Health = 1,
    Damage = 2,
    Speed = 3
}
