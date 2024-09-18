using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinsCounterUI;
    [SerializeField] private TextMeshProUGUI _timerUI;
    [SerializeField] private GameObject _gameLoseWindow;
    [SerializeField] private GameObject _gameWinWindow;

    private Timer _timer;
    private CoinController _coinCounter;

    private void Awake()
    {
        _timer = gameObject.GetComponent<Timer>();
        _coinCounter = gameObject.GetComponent<CoinController>();
    }
    private void Update()
    {
        UpdateCoinCounterUI();
        UpdateTimerUI();
    }

    private void UpdateTimerUI()
    {
        _timerUI.text = $"Time: {_timer.TimeRemainig.ToString("F0")} / {_timer.TimerGoal.ToString("F0")}";
    }

    private void UpdateCoinCounterUI()
    {
        _coinsCounterUI.text = $"Coins: {_coinCounter.NumbersfActivatedCoins.ToString("F0")} / {_coinCounter.NumbersOfAllCoins.ToString("F0")}";
    }

    public void CloseAllWindows()
    {
        LoseWindowSetActive(false);
        WinWindowSetActive(false);
    }

    public void WinWindowSetActive(bool isActive)
    {
        _gameWinWindow.SetActive(isActive);
    }

    public void LoseWindowSetActive(bool isActive)
    {
        _gameLoseWindow.SetActive(isActive);
    }
}
