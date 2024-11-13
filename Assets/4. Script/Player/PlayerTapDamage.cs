using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PlayerTapDamage : MonoBehaviour
{
    private BigIntegerFilter filter;
    //Player Damage
    public BigInteger TapDamage { get; private set; }
    private float initTapDamage = 10;
    private float growthFactor = 1.5f;
    private float playerLevel = 1;

    //DPS
    private BigInteger MaxDPS = 0;
    private BigInteger CurrentDPS = 0;
    private float timeInterval = 1f;
    private Coroutine dpsCoroutine;

    public float PlayerLevel
    {
        get { return playerLevel; }
        set
        {
            float lastLevel = value;
            if (PlayerLevel < lastLevel)
            {
                PlayerLevel = lastLevel;
                SetCurrentDamage(PlayerLevel);
            }
        }

    }

    private void Awake()
    {
        filter = GetComponent<BigIntegerFilter>();
    }

    private void Start()
    {
        TapDamage = new BigInteger(initTapDamage);
        filter.SetBigInteger(key: "TapDamage", TapDamage);
        filter.SetBigInteger(key: "CurrentDPS", CurrentDPS);
        filter.SetBigInteger(key: "MaxDPS", MaxDPS);
        dpsCoroutine = StartCoroutine(DPSMeasurementRoutine());
    }

    private void SetCurrentDamage(float level)
    {
        float setResult = initTapDamage * Mathf.Pow(level, growthFactor);
        TapDamage = new BigInteger(setResult);
        filter.SetBigInteger(key: "TapDamage", TapDamage);
    }

    private IEnumerator DPSMeasurementRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeInterval);

            CalculateDPS();
        }
    }

    public void AddDamage(BigInteger damage)
    {
        CurrentDPS += damage;
    }

    private void CalculateDPS()
    {
        BigInteger DPSResult = CurrentDPS;
        if (MaxDPS < DPSResult)
        {
            MaxDPS = DPSResult;
        }
        filter.SetBigInteger(key: "CurrentDPS", DPSResult);
        filter.SetBigInteger(key: "MaxDPS", MaxDPS);

        CurrentDPS = 0;
    }
}
