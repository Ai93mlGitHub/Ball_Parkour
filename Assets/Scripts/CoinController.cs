using UnityEngine;

public class CoinController : MonoBehaviour
{
    public int NumbersOfAllCoins { get; private set; }
    public int NumbersfActivatedCoins { get; private set; }

    private GameObject[] coins;

    private void Awake()
    {
        GetCoinObjects();
        NumbersOfAllCoins = coins.Length;
        ResetCoinsCounter();
    }

    public int GetCoinCount()
    {
        Coin[] coins = FindObjectsOfType<Coin>(); ;

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

    private void GetCoinObjects()
    {
        Coin[] coinComponents = FindObjectsOfType<Coin>();
        coins = new GameObject[coinComponents.Length];

        for (int i = 0; i < coinComponents.Length; i++)
        {
            coins[i] = coinComponents[i].gameObject;
        }
    }

    public void ResetCoinsOnScene()
    {
        foreach(GameObject coin in coins)
        {
            coin.SetActive(true);
        }
    }
}
