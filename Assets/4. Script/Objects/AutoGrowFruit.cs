using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class AutoGrowFruit : Fruit, ISkillToggleable
{
    private IInteractable targetInteractable;
    private Coroutine autoCoroutine;
    private float autoClickInterval = 0.5f;
    public float AutoClickInterval
    {
        //TODO : AutoClick의 제한을 두자.
        get { return autoClickInterval; }
        set { autoClickInterval = value; }
    }

    private void Start()
    {
        InitRaycastHit2D();
        //TODO 버튼에 올리고 Activate 실행
        Activate();
    }

    private void InitRaycastHit2D()
    {
        int layerMask = 1 << LayerNames.Tree;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero, Mathf.Infinity, layerMask);
        targetInteractable = hit.collider.GetComponent<IInteractable>();
        targetInteractable.Interact();
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
            targetInteractable?.Interact();
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

}
