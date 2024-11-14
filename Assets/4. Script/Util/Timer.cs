using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float maxTime = 60f;
    private float remainingTime;

    private void Start()
    {
        TimeReset();
    }

    private void Update()
    {
        UpdateCountDown();
        UpdateUITime();
        CheckTimeUp();
    }

    public void TimeReset()
    {
        remainingTime = maxTime;
    }

    private void UpdateCountDown()
    {
        remainingTime -= Time.deltaTime;
    }
    private void UpdateUITime()
    {
        UIManager.Instance.UITimer.UpdateUITime(remainingTime, maxTime);
    }

    private void CheckTimeUp()
    {
        if (remainingTime <= 0)
        {
            remainingTime = 0;
            GameManager.Instance.GameOver();
        }
    }

}
