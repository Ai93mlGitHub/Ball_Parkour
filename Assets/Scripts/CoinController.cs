using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] private CoinCounter _coinCounter;

    private void OnTriggerEnter(Collider other)
    {
        _coinCounter.AddActivatedCoin();
        gameObject.SetActive(false);
    }
}
