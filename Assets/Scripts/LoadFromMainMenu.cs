using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadFromMainMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public void PlayGame()
    {
        PlayerPrefs.SetInt("HealthLevel", 0);
        PlayerPrefs.SetInt("SpeedLevel",  0);
        PlayerPrefs.SetInt("DamageLevel", 0);
        PlayerPrefs.SetInt("PlayerCoins", 5);
        
        SceneManager.LoadScene("SampleScene");
    }
}
