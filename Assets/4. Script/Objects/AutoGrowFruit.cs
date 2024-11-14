using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class AutoGrowFruit : Fruit, ISkillToggleable
{
    private IInteractable targetInteractable;
    private PlayerTapDamage playerTapDamage;
    private BigIntegerFilter filter;
    private Coroutine autoCoroutine;
    private float autoClickInterval = 0.5f;

    private BigInteger autoDamage;
    private float initAutoDamage = 1;
    private float growthFactor = 1.1f;
    private float autoDamageLevel = 1;

    private BigInteger CurrentAutoDPS = 0;
    private Coroutine autoDPSCoroutine;
    private float timeInterval = 1f;

    public float AutoClickInterval
    {
        //TODO : AutoClick의 제한을 두자.
        get { return autoClickInterval; }
        set { autoClickInterval = value; }
    }

    private void Awake()
    {
        playerTapDamage = GetComponentInParent<PlayerTapDamage>();
        filter = GetComponentInParent<BigIntegerFilter>();
        autoDamage = new BigInteger(initAutoDamage);
    }

    private void Start()
    {
        InitRaycastHit2D();
        autoDPSCoroutine = StartCoroutine(AutoDPSMeasurementRoutine());
    }

    private void InitRaycastHit2D()
    {
        int layerMask = 1 << LayerNames.Tree;
        Collider2D collider = Physics2D.OverlapPoint(transform.position, layerMask);
        if (collider == null) { return; }
        targetInteractable = collider.GetComponent<IInteractable>();

        if (targetInteractable != null)
        {
            targetInteractable.Interact(autoDamage);
        }
        else
        {
            return;
        }
    }

    private IEnumerator AutoDPSMeasurementRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeInterval);

            CalculateAutoDPS();
        }
    }
    public void AddAutoDamage(BigInteger damage)
    {
        CurrentAutoDPS += damage;
        playerTapDamage.AddTotalDamage(damage);
    }
    private void CalculateAutoDPS()
    {
        BigInteger autoDPSResult = CurrentAutoDPS;
        filter.SetBigInteger(key: "AutoDPS", autoDPSResult);
        CurrentAutoDPS = 0;
    }

    public void Activate()
    {
        CoroutineCheckAndStop();
        autoCoroutine = StartCoroutine(AutoClickRoutine());
    }

    public void Deactivate()
    {
        CoroutineCheckAndStop();
    }

    private IEnumerator AutoClickRoutine()
    {
        while (true)
        {
            targetInteractable?.Interact(autoDamage);
            AddAutoDamage(autoDamage);
            yield return new WaitForSeconds(autoClickInterval);
        }
    }

    private void CoroutineCheckAndStop()
    {
        if (autoCoroutine != null)
        {
            StopCoroutine(autoCoroutine);
            autoCoroutine = null;
        }
    }

    public void TogglePanel()
    {
        bool isActive = !gameObject.activeSelf;
        gameObject.SetActive(isActive);
        if (isActive)
        {
            Activate();
        }
        else
        {
            Deactivate();
        }
    }

    public void autoDamageLevelUP()
    {
        if(!gameObject.activeSelf) { return; }
        autoDamageLevel++;
        SetCurrentDamage(autoDamageLevel);
        UIManager.Instance.UIShopWindow.autoLevel.ShowLevel(autoDamageLevel);
    }

    private void SetCurrentDamage(float level)
    {
        float setResult = initAutoDamage * Mathf.Pow(level, growthFactor);
        autoDamage = new BigInteger(setResult);

    }
}
