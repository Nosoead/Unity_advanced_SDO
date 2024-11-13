using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using UnityEngine;

public class BigIntegerFilter : MonoBehaviour
{
    public StatusListSO statusListSO;
    private static readonly string[] StandardUnits = { "", "K", "M", "G", "T" };

    public void SetBigInteger(string key, BigInteger value)
    {
        string bigToString = Filter(value);
        RaiseUIUpdateEvent(key, bigToString);
    }

    private void RaiseUIUpdateEvent(string key, string value)
    {
        statusListSO.RaiseUIUpdateEvent(key, value);
    }

    private string Filter(BigInteger value)
    {
        BigInteger thousand = new BigInteger(1000);
        int unitIndex = 0;
        decimal displayValue = (decimal)value;

        while (displayValue >= 1000)
        {
            displayValue /= 1000;
            unitIndex++;
        }

        // Standard units (K, M, G, T까지)
        if (unitIndex < StandardUnits.Length)
        {
            return $"{displayValue:F2}{StandardUnits[unitIndex]}";
        }

        // Custom alphabet units (A, B, ..., Z, AA, ...)
        unitIndex -= StandardUnits.Length - 1; // Standard 단위 이후에 알파벳 단위 시작
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
