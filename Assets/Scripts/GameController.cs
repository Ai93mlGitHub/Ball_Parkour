using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] Movement _playerMovement;
    [SerializeField] Rotator[] _rotatingObstacles;
    [SerializeField] Transform _groundBound;

    private Timer _timer;
    private CoinController _coinController;
    private UIController _uIController;
    private GameObject[] coins;
    private bool _isRunningGame;

    private void Awake()
    {
        _timer = gameObject.GetComponent<Timer>();
        _coinController = gameObject.GetComponent<CoinController>();
        _uIController = gameObject.GetComponent<UIController>();
    }

    private void Start()
    {
        GameStart();
    }

    private void Update()
    {
        if (_isRunningGame)
        {
            if (_timer.TimeOver)
                GameLose();

            if (_coinController.IsFullStack())
                GameWin();
        }

        if (_playerMovement.transform.position.y < _groundBound.position.y)
            _playerMovement.ResetPosition();
    }

    private void GameWin()
    {
        GameStop();
        _uIController.WinWindowSetActive(true);
    }

    private void GameLose()
    {
        GameStop();
        _uIController.LoseWindowSetActive(true);
    }

    public void GameStart()
    {
        ResetObjectsOnScene();
        _timer.ResetTimer();
        _coinController.ResetCoinsCounter();
        _uIController.CloseAllWindows();
        _playerMovement.UnFreeze();
        _playerMovement.ResetPosition();
        _isRunningGame = true;
    }

    private void ResetObjectsOnScene()
    {
        _coinController.ResetCoinsOnScene();

        foreach (Rotator obstacle in _rotatingObstacles)
        {
            obstacle.ResetRotation();
        }
    }

    public void GameStop()
    {
        _playerMovement.Freeze();
        _isRunningGame = false;
    }
}
