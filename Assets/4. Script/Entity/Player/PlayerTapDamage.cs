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
    private float damageLevel = 1;

    //DPS
    private BigInteger MaxDPS = 0;
    private BigInteger currentDPS = 0;
    private BigInteger totalDPS = 0;
    private float timeInterval = 1f;
    private Coroutine dpsCoroutine;

    private void Awake()
    {
        filter = GetComponent<BigIntegerFilter>();
    }

    private void Start()
    {
        TapDamage = new BigInteger(initTapDamage);
        filter.SetBigInteger(key: "TapDamage", TapDamage);
        filter.SetBigInteger(key: "CurrentDPS", currentDPS);
        filter.SetBigInteger(key: "MaxDPS", MaxDPS);
        dpsCoroutine = StartCoroutine(DPSMeasurementRoutine());
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
        currentDPS += damage;
        AddTotalDamage(currentDPS);
    }

    public void AddTotalDamage(BigInteger damage)
    {
        totalDPS += damage;
    }

    private void CalculateDPS()
    {
        BigInteger DPSResult = totalDPS;
        if (MaxDPS < DPSResult)
        {
            MaxDPS = DPSResult;
        }
        filter.SetBigInteger(key: "CurrentDPS", DPSResult);
        filter.SetBigInteger(key: "MaxDPS", MaxDPS);

        currentDPS = 0;
        totalDPS = 0;
    }

    public void DamageLevelUP()
    {
        damageLevel++;
        SetCurrentDamage(damageLevel);
        UIManager.Instance.UIShopWindow.damageLevel.ShowLevel(damageLevel);
    }

    private void SetCurrentDamage(float level)
    {
        float setResult = initTapDamage * Mathf.Pow(level, growthFactor);
        TapDamage = new BigInteger(setResult);
        filter.SetBigInteger(key: "TapDamage", TapDamage);
    }
}
