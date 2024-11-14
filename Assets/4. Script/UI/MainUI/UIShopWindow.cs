using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

//상점창입니다.
public class UIShopWindow : MonoBehaviour
{
    public UIDamageLevel damageLevel;
    public UIAutoLevel autoLevel;
    public UIMoneyLevel moneyLevel;
    public UIFruitValue fruitValue;

    private void Awake()
    {
        damageLevel = GetComponentInChildren<UIDamageLevel>();
        autoLevel = GetComponentInChildren<UIAutoLevel>();
        moneyLevel = GetComponentInChildren<UIMoneyLevel>();
        fruitValue = GetComponentInChildren<UIFruitValue>();
    }

    public void TogglePanel()
    {
        bool isActive = !gameObject.activeSelf;
        gameObject.SetActive(isActive);
        GameManager.Instance.tree.ToggleCollider(!isActive);
    }
}
