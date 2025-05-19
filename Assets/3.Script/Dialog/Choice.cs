using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Choice : MonoBehaviour, IPointerClickHandler
{
    [HideInInspector]
    public ChoiceData choiceData;
    public Action<ChoiceData> clickEvent;


    TextMeshProUGUI choiceText;

    public void OnPointerClick(PointerEventData eventData)
    {
        clickEvent?.Invoke(choiceData);
    }

    public virtual void Init()
    {
        choiceText = GetComponentInChildren<TextMeshProUGUI>();

        choiceText.text = choiceData.choiceText;
    }
}
