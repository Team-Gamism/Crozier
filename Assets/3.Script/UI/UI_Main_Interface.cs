using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UI_Main_Interface : MonoBehaviour
{

    [SerializeField]
    AudioClip buttonEnterSound;
    [SerializeField]
    AudioClip buttonClickSound;

    AudioSource audioSource;

    

    GameObject startButton;
    GameObject settingButton;
    GameObject exitButton;

    public UI_Fade fadeUI;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        startButton = Util.FindChild(gameObject,"Start",true);
        settingButton = Util.FindChild(gameObject,"Setting",true);
        exitButton = Util.FindChild(gameObject,"Exit",true);

        UI_EventHandler evt = startButton.GetComponent<UI_EventHandler>();
        evt.enterAction += (PointerEventData p) => { startButton.transform.DOLocalMoveX(-932,0.6f); audioSource.PlayOneShot(buttonEnterSound); };
        evt.exitAction += (PointerEventData p) => { startButton.transform.DOLocalMoveX(-1032, 0.6f); };

        evt = settingButton.GetComponent<UI_EventHandler>();
        evt.enterAction += (PointerEventData p) => { settingButton.transform.DOLocalMoveX(-932, 0.6f); audioSource.PlayOneShot(buttonEnterSound); };
        evt.exitAction += (PointerEventData p) => { settingButton.transform.DOLocalMoveX(-1032, 0.6f);  };

        evt = exitButton.GetComponent<UI_EventHandler>();
        evt.enterAction += (PointerEventData p) => { exitButton.transform.DOLocalMoveX(-932, 0.6f); audioSource.PlayOneShot(buttonEnterSound); };
        evt.exitAction += (PointerEventData p) => { exitButton.transform.DOLocalMoveX(-1032, 0.6f); };
    }




    public void StartGame()
    {
        audioSource.PlayOneShot(buttonClickSound);
        fadeUI.FadeIn("Map");
    }

    public void Setting()
    {
        audioSource.PlayOneShot(buttonClickSound);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
