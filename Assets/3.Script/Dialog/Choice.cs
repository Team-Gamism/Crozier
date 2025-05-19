using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Choice : MonoBehaviour, IPointerClickHandler
{
    [HideInInspector]
    public ChoiceData choiceData;
    public Action<ChoiceData> clickEvent;


    Text choiceText;

    public void OnPointerClick(PointerEventData eventData)
    {
        clickEvent?.Invoke(choiceData);
    }

    public virtual void Init()
    {
        choiceText = GetComponentInChildren<Text>();

        choiceText.text = choiceData.choiceText;
    }
}
