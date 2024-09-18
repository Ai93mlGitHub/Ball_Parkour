using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private CoinController _coinCounter;

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();

        if (player != null)
        {
            _coinCounter.AddActivatedCoin();
            gameObject.SetActive(false);
        }
    }
}
