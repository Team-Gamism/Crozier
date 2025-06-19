using DG.Tweening;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

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

    StageSO stageSO;

    Animator anim;

    private void Start()
    {
        title = Util.FindChild<TextMeshProUGUI>(gameObject,"Title",true);
        descirption = Util.FindChild<TextMeshProUGUI>(gameObject,"Description",true);
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        for(int i = 0; i < houseList.Count; i++)
        {
            UI_EventHandler evt = houseList[i].GetComponent<UI_EventHandler>();
            evt.clickAction += (PointerEventData p) => { stageSO = evt.GetComponent<StageUI>().stageSO; SetTextUI(); anim.Play("Show"); audioSource.PlayOneShot(audioClip); };
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
        fadeUI.FadeIn(stageSO.sceneName);
    }
}
