using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

//나무에서 열매가 스폰되는 곳입니다. 이쁘게하는것 고사하고 오브젝트 만드는 과정이 너무 찝찝한 부분입니다.
//오브젝트를 확률에따라 이미지랑 바꾸고 등장할때 총 돈값 계산해서 올립니다.
public class TreeFruitSpawner : MonoBehaviour
{
    [SerializeField] public List<Sprite> fruitSprite;
    [SerializeField] private Transform spawnPositionsRoot;
    [SerializeField] private GameObject fruitPrefab;
    private List<GameObject> fruits = new List<GameObject>();
    public BigInteger money { get; private set; }

    private float moneyLevel = 1;

    private BigInteger bronzeValue;
    private float initBronzeValue = 10;
    private float bronzeGrowthFactor = 1.1f;

    private BigInteger silverValue;
    private float initSilverValue = 50;
    private float silverGrowthFactor = 1.2f;

    private BigInteger GoldValue;
    private float initGoldValue = 200;
    private float GoldGrowthFactor = 1.3f;

    private float fruitValueLevel = 0;
    private float MaxfruitValueLevel = 20;

    private float bronzeProbability;
    private float silverProbability;
    private float goldProbability;

    private void Awake()
    {
        MakeFruitPool();
        CalculateSpawnProbability(fruitValueLevel, out bronzeProbability, out silverProbability, out goldProbability);

    }
    private void Start()
    {
        money = 0;
        bronzeValue = new BigInteger(initBronzeValue);
        silverValue = new BigInteger(initSilverValue);
        GoldValue = new BigInteger(initGoldValue);
    }

    private void MakeFruitPool()
    {
        for (int i = 0; i < spawnPositionsRoot.childCount; i++)
        {
            Transform spawnPosition = spawnPositionsRoot.GetChild(i);
            GameObject newFruit = Instantiate(fruitPrefab, spawnPosition.position, UnityEngine.Quaternion.identity);
            newFruit.SetActive(true);
            fruits.Add(newFruit);
        }
    }

    public void CalculateSpawnProbability(float valueLevel, out float bronzeProbability, out float silverProbability, out float goldProbability)
    {
        bronzeProbability = Mathf.Max(100 - (valueLevel * 5), 0) / 100;
        silverProbability = Mathf.Max(100 - Mathf.Abs(valueLevel - 10) * 10, 0) / 100;
        goldProbability = Mathf.Min(valueLevel * 5, 100) / 100;
    }

    public void GenerateFruitWithProbability()
    {
        for (int i = 0; i < fruits.Count; i++)
        {
            fruits[i].SetActive(true);
            float randomValue = Random.value;
            int fruitIndex = 0;

            if (randomValue <= bronzeProbability)
            {
                fruitIndex = 0;
                money += bronzeValue;
            }
            else if (randomValue <= bronzeProbability + silverProbability)
            {
                fruitIndex = 1;
                money += silverValue;
            }
            else
            {
                fruitIndex = 2;
                money += GoldValue;
            }
            if (fruitIndex >= 0 && fruitIndex < fruitSprite.Count)
            {
                if (fruits[i].TryGetComponent(out SpriteRenderer spriteRenderer))
                {
                    spriteRenderer.sprite = fruitSprite[fruitIndex];
                }
            }
        }
    }

    #region /UI Button 레벨업 및 정보 업데이트
    public void RewardOnTreeLevelUp()
    {
        GameManager.Instance.player.GetMoney(money);
        for (int i = 0; i < fruits.Count; i++)
        {
            fruits[i].SetActive(false);
        }
    }

    public void MoneyLevelUp()
    {
        moneyLevel++;
        SetCurrentMoneyValue(moneyLevel);
        UIManager.Instance.UIShopWindow.moneyLevel.ShowLevel(moneyLevel);
    }

    private void SetCurrentMoneyValue(float level)
    {
        float setBronzeResult = initBronzeValue * Mathf.Pow(level, bronzeGrowthFactor);
        float setSilverResult = initSilverValue * Mathf.Pow(level, silverGrowthFactor);
        float setGoldResult = initGoldValue * Mathf.Pow(level, GoldGrowthFactor);
        bronzeValue = new BigInteger(setBronzeResult);
        silverValue = new BigInteger(setSilverResult);
        GoldValue = new BigInteger(setGoldResult);
    }

    public void fruitValueLevelUP()
    {
        if (fruitValueLevel >= MaxfruitValueLevel)
        {
            return;
        }
        else
        {
            fruitValueLevel++;
            CalculateSpawnProbability(fruitValueLevel, out bronzeProbability, out silverProbability, out goldProbability);
            UIManager.Instance.UIShopWindow.fruitValue.ShowLevel(fruitValueLevel);
        }
    }
    #endregion
}
