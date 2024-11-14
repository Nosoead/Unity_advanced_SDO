using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Events;

//SO�� �����ϸ� ���ζ�� �ǵ���� �ޱ����� �۾��ؼ� �̷� ����� �� ���غ����� �մϴ�. ������ ItemManager��� SO���� ItemSO �� �ִ� ����� ��ȸ�� ���� �غ����� �մϴ�.
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
