using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
