using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TypingText : MonoBehaviour
{
    TextMeshProUGUI dialogTextUI;
    string dialogText = "";
    public Action endDialogAction;

    private void Awake()
    {
        dialogTextUI = GetComponent<TextMeshProUGUI>();
    }

    public void TypeingText(DialogData dialogData)
    {
        StartCoroutine(CTypingText(dialogData));
    }


    IEnumerator CTypingText(DialogData dialogData)
    {
        int index = 0;
        dialogText = "";
        string resultText = dialogData.textData;
        while (index < resultText.Length)
        {
            string letter = resultText.Substring(index, 1);


            dialogText += letter;
            dialogTextUI.text = dialogText;

            index++;
            if (dialogData.typingTime != 0)
                yield return new WaitForSeconds(dialogData.typingTime);
        }

        endDialogAction.Invoke();
    }
}
