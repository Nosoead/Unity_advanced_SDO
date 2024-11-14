using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIMoneyLevel : MonoBehaviour
{
    private TextMeshProUGUI LevelTxt;

    private void Awake()
    {
        LevelTxt = GetComponentInChildren<TextMeshProUGUI>();
        ShowLevel(1);
    }
    public void ShowLevel(float level)
    {
        LevelTxt.text = $"MoneyLevel : {level}";
    }
}
