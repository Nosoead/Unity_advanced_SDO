using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

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
