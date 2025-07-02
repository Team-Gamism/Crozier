using System;
using System.Collections;
using System.Linq;
using TMPro;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class DialogMarkerData
{
    public string Massage;
    public float PausePerLetter;
    public string Name;
}

public class DialogAnimator : MonoBehaviour
{
    GameObject textBox;
    TextMeshProUGUI dialogUIText;
    TextMeshProUGUI nameText;
    PlayableDirector director;
    


    string dialogText;
    bool stopTyping;
    bool isTyping;

    private void Start()
    {
        director = GetComponent<PlayableDirector>();
        textBox = Util.FindChild(gameObject,"UI_Dialog",true);
        dialogUIText = Util.FindChild<TextMeshProUGUI>(gameObject,"DialogText",true);
        nameText = Util.FindChild<TextMeshProUGUI>(gameObject,"NameText",true);
        textBox.SetActive(false);
    }

    public void AddDialog(DialogMarkerData dialog)
    {
        if (nameText != null)
            nameText.text = dialog.Name;
        StartCoroutine(Typing(dialog));
    }

    IEnumerator Typing(DialogMarkerData dialogData)
    {
        int index = 0;
        dialogText = "";
        string resultText = dialogData.Massage;
        stopTyping = false;
        isTyping = true;
        StartCoroutine(CheckStopTypeing());
        while (index < resultText.Length)
        {
            string letter = resultText.Substring(index, 1);


            dialogText += letter;
            dialogUIText.text = dialogText;

            index++;
            if (!stopTyping)
                yield return new WaitForSeconds(dialogData.PausePerLetter);
        }

        isTyping = false;
        StartCoroutine(NextDialogTrigger());
        StartCoroutine(ShowDialogSign());
    }

    IEnumerator NextDialogTrigger()
    {
        while (true)
        {
            yield return null;
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                director.Play();
                StopDialogSign();
            }
        }
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
            dialogUIText.text += "<sprite name=Crozier>";
            yield return new WaitForSeconds(0.8f);

            dialogUIText.text = dialogText;
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
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                stopTyping = true;
            }
        }
    }

   
}
