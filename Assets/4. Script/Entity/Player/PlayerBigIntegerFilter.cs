using System.Numerics;
using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;

//큰수 필터링해서 SO에 있는 이벤트타고 UI로 쏴줍니다.
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