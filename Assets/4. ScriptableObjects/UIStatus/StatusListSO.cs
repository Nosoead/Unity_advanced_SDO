using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Events;

//SO로 생성하면 별로라는 피드백을 받기전에 작업해서 이런 방법은 좀 피해보려고 합니다. 하지만 ItemManager대신 SO에서 ItemSO 쭉 넣는 방법은 기회가 오면 해보려고 합니다.
[CreateAssetMenu(fileName = "StatusListSO", menuName = "ScriptableObject/StatusListSO", order = 1)]
public class StatusListSO : ScriptableObject
{
    [Header("StatusUI")]
    public List<StatusSO> statusSOs = new List<StatusSO>();

    public UnityAction<string, string> OnUIUpdateEvent;

    public void RaiseUIUpdateEvent(string key, string value)
    {
        OnUIUpdateEvent?.Invoke(key, value);
    }
}
