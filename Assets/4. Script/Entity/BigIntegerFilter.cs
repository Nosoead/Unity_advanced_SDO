using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using UnityEngine;

//큰수에 대한 필터 관련인데, 솔직히 1000단위로 해서 막연한 아이디어만 있어서 GPT쓰고 분석하고 이상한거 고치고 이랬습니다.
public class BigIntegerFilter : MonoBehaviour
{

    protected static readonly string[] StandardUnits = { "", "K", "M", "G", "T" };

    public virtual void SetBigInteger(BigInteger currentValue, BigInteger MaxValue)
    {
    }

    public virtual void SetBigInteger(string key, BigInteger value)
    {
    }

    protected string Filter(BigInteger value)
    {
        BigInteger thousand = new BigInteger(1000);
        int unitIndex = 0;
        decimal displayValue = (decimal)value;

        while (displayValue >= 1000)
        {
            displayValue /= 1000;
            unitIndex++;
        }

        
        if (unitIndex < StandardUnits.Length)
        {
            return $"{displayValue:F2}{StandardUnits[unitIndex]}";
        }

        unitIndex -= StandardUnits.Length - 1;
        StringBuilder unitBuilder = new StringBuilder();

        while (unitIndex >= 0)
        {
            int letterIndex = unitIndex % 26;
            char letter = (char)('A' + letterIndex);
            unitBuilder.Insert(0, letter);
            unitIndex = (unitIndex / 26) - 1;
        }

        return $"{displayValue:F2}{unitBuilder}";
    }
}
