using System;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    public int NumbersOfAllCoins { get; private set; }

    public int NumbersfActivatedCoins { get; private set; }

    private void Awake()
    {
        NumbersOfAllCoins = GetCoinCount();
        ResetCoinsCounter();
    }

    public int GetCoinCount()
    {
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");

        return coins.Length;
    }

    public void AddActivatedCoin()
    {
        NumbersfActivatedCoins++;
    }

    public bool IsFullStack()
    {
        return NumbersfActivatedCoins == NumbersOfAllCoins;
    }

    public void ResetCoinsCounter()
    {
        NumbersfActivatedCoins = 0;
    }


}
