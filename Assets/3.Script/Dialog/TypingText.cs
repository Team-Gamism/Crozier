using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TypingText : MonoBehaviour
{
    TextMeshProUGUI dialogTextUI;
    string dialogText = "";
    public Action endDialogAction;

    bool isTyping;
    bool stopTyping;
    bool stopDialogSign;

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
        stopTyping = false;
        isTyping = true;
        StartCoroutine(CheckStopTypeing());
        while (index < resultText.Length)
        {
            string letter = resultText.Substring(index, 1);


            dialogText += letter;
            dialogTextUI.text = dialogText;

            index++;
            if (!stopTyping)
                yield return new WaitForSeconds(dialogData.typingTime);
        }

        isTyping = false;
        StartCoroutine(ShowDialogSign());
        endDialogAction.Invoke();
    }

    public void StopDialogSign()
    {
       StopAllCoroutines();
    }

    IEnumerator ShowDialogSign()
    {
        while (true)
        {
           
            yield return null;
            dialogTextUI.text += "<sprite name=Crozier>";
            yield return new WaitForSeconds(0.8f);
           
            dialogTextUI.text = dialogText;
            yield return new WaitForSeconds(0.8f);
        }
    }


    IEnumerator CheckStopTypeing()
    {
        while (true)
        {
            if (!isTyping)
                yield break;

            yield return null;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                stopTyping = true;
            }
        }
    }
}
