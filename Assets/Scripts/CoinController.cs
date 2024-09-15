using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] private CoinCounter _coinCounter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _coinCounter.AddActivatedCoin();
            gameObject.SetActive(false);
        }
    }
}
