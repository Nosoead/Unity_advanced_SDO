using System.Numerics;
using System.Text;
using UnityEngine;


//나무랑 플레이어랑 다르게 데이터를 넘겨줘야해서 상속만 받고 생성자를 오버로드해서 사용했습니다.
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