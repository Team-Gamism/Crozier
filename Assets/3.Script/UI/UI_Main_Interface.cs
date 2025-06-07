using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UI_Main_Interface : MonoBehaviour
{
    GameObject startButton;
    GameObject settingButton;
    GameObject exitButton;

    public UI_Fade fadeUI;
    private void Start()
    {
        startButton = Util.FindChild(gameObject,"Start",true);
        settingButton = Util.FindChild(gameObject,"Setting",true);
        exitButton = Util.FindChild(gameObject,"Exit",true);

        UI_EventHandler evt = startButton.GetComponent<UI_EventHandler>();
        evt.enterAction += (PointerEventData p) => { startButton.transform.DOLocalMoveX(-932,0.6f); };
        evt.exitAction += (PointerEventData p) => { startButton.transform.DOLocalMoveX(-1032, 0.6f); };

        evt = settingButton.GetComponent<UI_EventHandler>();
        evt.enterAction += (PointerEventData p) => { settingButton.transform.DOLocalMoveX(-932, 0.6f); };
        evt.exitAction += (PointerEventData p) => { settingButton.transform.DOLocalMoveX(-1032, 0.6f); };

        evt = exitButton.GetComponent<UI_EventHandler>();
        evt.enterAction += (PointerEventData p) => { exitButton.transform.DOLocalMoveX(-932, 0.6f); };
        evt.exitAction += (PointerEventData p) => { exitButton.transform.DOLocalMoveX(-1032, 0.6f); };
    }




    public void StartGame()
    {
        fadeUI.FadeIn("SC");
    }

    public void Setting()
    {

    }

    public void Exit()
    {
        Application.Quit();
    }
}
