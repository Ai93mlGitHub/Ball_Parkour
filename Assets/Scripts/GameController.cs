using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] Movement _playerMovement;
    [SerializeField] Rotation[] _rotatingObstacles; 

    private Timer _timer;
    private CoinCounter _coinCounter;
    private UIController _uIController;
    private GameObject[] coins;

    private void Awake()
    {
        _timer = gameObject.GetComponent<Timer>();
        _coinCounter = gameObject.GetComponent<CoinCounter>();
        _uIController = gameObject.GetComponent<UIController>();
    }

    private void Start()
    {
        coins = GameObject.FindGameObjectsWithTag("Coin");
        GameStart();

    }

    private void Update()
    {
        if (_timer.TimeOver)
            GameLose();

        if (_coinCounter.IsFullStack())
            GameWin();
    }

    private void GameWin()
    {
        GameStop();
        _uIController.WinWindowActivate();
    }

    private void GameLose()
    {
        GameStop();
        _uIController.LoseWindowActivate();
    }

    public void GameStart()
    {
        ResetObjectsOnScene();
        _timer.ResetTimer();
        _coinCounter.ResetCoinsCounter();
        _uIController.CloseAllWindows();
        _playerMovement.UnFreeze();
        _playerMovement.ResetPosition();
    }

    private void ResetObjectsOnScene()
    {
        foreach(GameObject coin in coins)
        {
            coin.SetActive(true);
        }

        foreach(Rotation obstacle in _rotatingObstacles)
        {
            obstacle.ResetRotation();
        }
    }

    public void GameStop()
    {
        _playerMovement.Freeze();
    }
}
