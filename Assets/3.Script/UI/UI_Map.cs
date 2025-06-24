using DG.Tweening;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Map : MonoBehaviour
{
    public List<GameObject> houseList;

    [SerializeField]
    UI_Fade fadeUI;
    [SerializeField]
    AudioClip audioClip;

    AudioSource audioSource;

    TextMeshProUGUI title;
    TextMeshProUGUI descirption;

    [SerializeField] Sprite houseSprite;

    int index;
    StageSO stageSO;

    Animator anim;

    private void Start()
    {
        title = Util.FindChild<TextMeshProUGUI>(gameObject, "Title", true);
        descirption = Util.FindChild<TextMeshProUGUI>(gameObject, "Description", true);
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        if (!SingleTon<GameManager>.Instance.isStartedNewGame)
        {
            SingleTon<GameManager>.Instance.completeJudgementList = new();
            for (int i = 0; i < houseList.Count; i++)
            {
                SingleTon<GameManager>.Instance.completeJudgementList.Add(false);
            }
            SingleTon<GameManager>.Instance.isStartedNewGame = true;
        }
        for (int i = 0; i < houseList.Count; i++)
        {
            houseList[i].GetComponent<StageUI>().index = i;
        }

        for (int i = 0; i < houseList.Count; i++)
        {
            UI_EventHandler evt = houseList[i].GetComponent<UI_EventHandler>();
            if (!SingleTon<GameManager>.Instance.completeJudgementList[i])
            {
                evt.clickAction += (PointerEventData p) => { index = evt.GetComponent<StageUI>().index; stageSO = evt.GetComponent<StageUI>().stageSO; SetTextUI(); anim.Play("Show"); audioSource.PlayOneShot(audioClip); };
                evt.enterAction += (PointerEventData p) => { evt.GetComponent<StageUI>().EnterAction(); };
                evt.exitAction += (PointerEventData p) => { evt.GetComponent<StageUI>().ExitAction(); };
            }
            else
            {
                evt.GetComponent<Image>().sprite = houseSprite;
                evt.GetComponent<RectTransform>().sizeDelta = new Vector2(95, 95);
            }
        }

       

    }

    void SetTextUI()
    {
        title.text = stageSO.title;
        descirption.text = stageSO.description;
    }

    public void Close()
    {
        anim.Play("Hide");
    }

    public void Play()
    {
        SingleTon<GameManager>.Instance.completeJudgementList[index] = true;
        fadeUI.FadeIn(stageSO.sceneName);
    }
}
