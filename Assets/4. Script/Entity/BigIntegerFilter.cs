using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using UnityEngine;

//ū���� ���� ���� �����ε�, ������ 1000������ �ؼ� ������ ���̵� �־ GPT���� �м��ϰ� �̻��Ѱ� ��ġ�� �̷����ϴ�.
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
