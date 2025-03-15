using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    
    void Start()
    {
        
    }

    public void TakeDamageUI(float newAmount)
    {
        healthBar.fillAmount = newAmount;
        print("takedamageUI");
       
    } 

    // Update is called once per frame
    void Update()
    {
        
    }
}
