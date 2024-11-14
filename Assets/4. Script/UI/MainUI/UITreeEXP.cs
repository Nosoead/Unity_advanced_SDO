using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//게임 상단부 나무 EXP관련입니다.
public class UITreeEXP : MonoBehaviour
{
    private Image EXPImage;
    private TextMeshProUGUI EXPTxt;
    private TextMeshProUGUI levelTxt;

    private void Awake()
    {
        EXPImage = GetComponent<Image>();
        EXPTxt = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void UpdateUITreeEXP(float percent, string expTxt, string MaxEXPTxt)
    {
        UpdateImage(percent);
        UpdateText(expTxt, MaxEXPTxt);
    }

    private void UpdateImage(float percent)
    {
        EXPImage.fillAmount = percent;
    }

    private void UpdateText(string expTxt, string MaxEXPTxt)
    {
        EXPTxt.text = $"{expTxt}/{MaxEXPTxt}";
    }
}
