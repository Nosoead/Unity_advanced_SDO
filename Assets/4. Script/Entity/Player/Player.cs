using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

//플레이어에서 싱글톤으로 정보전달할 부분만 좀 넣어놨습니다.
public class Player : MonoBehaviour
{
    public PlayerInputController Controller { get; private set; }
    public PlayerTapDamage tapDamage {  get; private set; }
    public BigInteger playerMoney { get; private set; }

    private BigIntegerFilter filter;

    private void Awake()
    {
        Controller = GetComponent<PlayerInputController>();
        tapDamage = GetComponent<PlayerTapDamage>();
        filter = GetComponent<BigIntegerFilter>();
    }

    public void GetMoney(BigInteger money)
    {
        playerMoney += money;
        filter.SetBigInteger(key: "Money", playerMoney);
    }
}
