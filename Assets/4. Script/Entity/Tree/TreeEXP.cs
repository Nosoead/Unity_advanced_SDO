using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class TreeEXP : MonoBehaviour
{
    private BigIntegerFilter filter;
    private TreeFruitSpawner fruitSpawner;

    public BigInteger EXP { get; private set; }
    public BigInteger currentEXP { get; private set; }
    private float initEXP = 100;
    private float growthFactor = 2;
    private float stageLevel = 1;

    private void Awake()
    {
        filter = GetComponent<BigIntegerFilter>();
        fruitSpawner = GetComponentInChildren<TreeFruitSpawner>();
    }

    private void Start()
    {
        UIManager.Instance.UILevelTxt.UpdateUILevel(stageLevel);
        EXP = new BigInteger(initEXP);
        currentEXP = 0;
        filter.SetBigInteger(currentEXP, EXP);
        currentEXP = 0;
        fruitSpawner.GenerateFruitWithProbability();
    }

    public void GetTreeEXP(BigInteger exp)
    {
        currentEXP += exp;
        filter.SetBigInteger(currentEXP, EXP);
        CheckStageUp();
    }

    private void CheckStageUp()
    {
        if (currentEXP >= EXP)
        {
            currentEXP -= EXP;
            stageLevel++;
            fruitSpawner.RewardOnTreeLevelUp();
            fruitSpawner.GenerateFruitWithProbability();
            UIManager.Instance.UILevelTxt.UpdateUILevel(stageLevel);
            GameManager.Instance.timer.TimeReset();
            SetStageEXP(stageLevel);
        }
    }

    private void SetStageEXP(float StageLevel)
    {
        float setResult = initEXP * Mathf.Pow(StageLevel, growthFactor);
        EXP = new BigInteger(setResult);
    }
}
