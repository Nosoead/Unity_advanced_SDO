using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class UILevelTxt : MonoBehaviour
{
    private TextMeshProUGUI levelTxt;

    private void Awake()
    {
        levelTxt = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateUILevel(float level)
    {
        levelTxt.text = $"LV{level}";
    }
}
