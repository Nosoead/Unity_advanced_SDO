using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Data;

public class UIStatusPanel : MonoBehaviour
{
    public StatusListSO statusListSO;
    private Dictionary<string, GameObject> UIStatusDictionary = new Dictionary<string, GameObject>();

    private void Awake()
    {
        if (statusListSO != null)
        {
            GenerateUIstatus();
        }
    }

    private void Start()
    {

    }

    private void GenerateUIstatus()
    {
        foreach (StatusSO statusSO in statusListSO.statusSOs)
        {
            GameObject newUI = Instantiate(statusSO.prefab, transform);
            newUI.name = statusSO.UIName;

            RectTransform rectTransform = newUI.GetComponent<RectTransform>();
            if (rectTransform != null)
            {
                rectTransform.anchoredPosition = statusSO.position;
                rectTransform.sizeDelta = statusSO.size;
                rectTransform.anchorMin = statusSO.anchorMin;
                rectTransform.anchorMax = statusSO.anchorMax;
                rectTransform.pivot = statusSO.pivot;
            }

            Image imageComponent = newUI.GetComponentInChildren<Image>();
            if (imageComponent != null)
            {
                imageComponent.sprite = statusSO.UIImage;
            }

            TextMeshProUGUI textComponent = newUI.GetComponentInChildren<TextMeshProUGUI>();
            if (textComponent != null)
            {
                textComponent.text = "0.00";
            }

            UIStatusDictionary[statusSO.UIName] = newUI;
        }
    }

    void OnEnable()
    {
        if (statusListSO != null)
        {
            statusListSO.OnUIUpdateEvent += UpdateUIStatus;
        }
    }

    void OnDisable()
    {
        if (statusListSO != null)
        {
            statusListSO.OnUIUpdateEvent -= UpdateUIStatus;
        }
    }

    private void UpdateUIStatus(string key, string value)
    {
        if (UIStatusDictionary.ContainsKey(key))
        {
            TextMeshProUGUI textComponent = UIStatusDictionary[key].GetComponentInChildren<TextMeshProUGUI>();
            if (textComponent != null)
            {
                textComponent.text = value;
            }
        }
    }
}