using TMPro;
using UnityEngine;
using UnityEngine.UI;

//UI자동 생성해보려고 했습니다. JSON으로 위치데이터 저장해서 생성하는 법을 귀로만 들었고 막상 구현하려니 갑갑해서 일단 이렇게 했습니다.
[CreateAssetMenu(fileName = "StatusSO", menuName = "ScriptableObject/StatusSO", order = 0)]
public class StatusSO : ScriptableObject
{
    [Header("Info")]
    public string UIName;
    public GameObject prefab;
    public Vector2 position;
    public Vector2 size;
    public Vector2 anchorMin;
    public Vector2 anchorMax;
    public Vector2 pivot;
    public Sprite UIImage;
    public TextMeshProUGUI text;
}
