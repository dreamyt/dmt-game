using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : Singleton<CoinManager>
{
    [SerializeField] int initialCoins = 50;
    public int Coins;
    public int tempCoins;
    public bool isSpellBought2 = false;
    public bool isSpellBought1 = false;
    public bool isWeaponBought = false;

    private readonly string KEY_COIN = "Civilization_MyCoins_EnjoyOurGame";

    private void Start()
    {
        GameObject.DontDestroyOnLoad(gameObject);
        PlayerPrefs.SetInt(KEY_COIN, initialCoins);
        tempCoins = initialCoins;
        LoadCoins();
    }


    public void PushTempCoins()
    {
        tempCoins = Coins;
    }
    
    public void PullTempCoins()
    {
        Coins = tempCoins;
    }

    private void LoadCoins()
    {
        Coins = PlayerPrefs.GetInt(KEY_COIN);
    }

    public void GetCoins(int amount)
    {
        Coins += amount;
    }
    
    public void LossCoins(int amount)
    {
        Coins -= amount;
        PlayerPrefs.SetInt(KEY_COIN, Coins);
    }

}
