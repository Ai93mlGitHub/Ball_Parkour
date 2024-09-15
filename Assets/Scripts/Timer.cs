using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _timerGoal;

    public float TimerGoal
    {
        get => _timerGoal;
        private set
        {
            if (value > 0)
            {
                _timerGoal = value;
            }
            else
            {
                Debug.LogWarning("TimerGoal must be greater than zero.");
            }
        }
    }

    public float TimeRemainig { get; private set; }

    public bool TimeOver { get; private set; } = false;

    private void Start()
    {
        ResetTimer();
    }

    void Update()
    {
        if (TimeRemainig > 0)
        {
            TimeRemainig -= Time.deltaTime;
        }
        else if (TimeOver == false)
        {
            TimeOver = true;
            TimeRemainig = 0;
        }
    }

    public void ResetTimer()
    {
        TimeRemainig = _timerGoal;
        TimeOver = false;
    }
}
