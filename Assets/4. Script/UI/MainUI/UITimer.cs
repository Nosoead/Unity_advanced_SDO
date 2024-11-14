using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

//게임 상단바 타이머이고, 값을 받아 노출만 해줍니다.
public class UITimer : MonoBehaviour
{
    private Image timeImage;
    private TextMeshProUGUI timeTxt;

    private void Awake()
    {
        timeImage = GetComponent<Image>();
        timeTxt = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void UpdateUITime(float remainingTime, float maxTime)
    {
        UpdateImage(remainingTime, maxTime);
        UpdateText(remainingTime);
    }

    private void UpdateImage(float remainingTime, float maxTime)
    {
        timeImage.fillAmount = remainingTime / maxTime;
    }

    private void UpdateText(float remainingTime)
    {
        timeTxt.text = remainingTime.ToString("F1");
    }

}
