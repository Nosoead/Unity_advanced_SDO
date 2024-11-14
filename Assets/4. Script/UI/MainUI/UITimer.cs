using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


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
