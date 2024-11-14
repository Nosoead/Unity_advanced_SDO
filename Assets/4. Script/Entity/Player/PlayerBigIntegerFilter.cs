using System.Numerics;
using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBigIntegerFilter : BigIntegerFilter
{
    public StatusListSO statusListSO;

    public override void SetBigInteger(string key, BigInteger value)
    {
        string bigToString = Filter(value);
        RaiseUIUpdateEvent(key, bigToString);
    }

    private void RaiseUIUpdateEvent(string key, string value)
    {
        statusListSO.RaiseUIUpdateEvent(key, value);
    }
}