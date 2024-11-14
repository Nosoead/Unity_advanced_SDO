using System.Numerics;
using System.Text;
using UnityEngine;

public class TreeBigIntegerFilter : BigIntegerFilter
{
    public override void SetBigInteger(BigInteger currentValue, BigInteger MaxValue)
    {
        float expPercent = (float)currentValue / (float)MaxValue;
        string currentValueTxt = Filter(currentValue);
        string MaxValueTxt = Filter(MaxValue);
        UpdateUITreeEXP(expPercent, currentValueTxt, MaxValueTxt);
    }

    private void UpdateUITreeEXP(float percent, string expTxt, string MaxEXPTxt)
    {
        UIManager.Instance.UITreeEXP.UpdateUITreeEXP(percent, expTxt, MaxEXPTxt);
    }
}