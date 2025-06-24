using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Fade : MonoBehaviour
{
    string sceneName;
    public Animator introUI;

    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        if (GameManager.Instance.isIntroShown)
        {
            anim.Play("FadeOut");
            if(introUI != null)
                introUI.Play("Default");
        }
        else
        {
            introUI.Play("Start");
            GameManager.Instance.isIntroShown = true;
        }
    }

    public void FadeIn(string sceneName)
    {
        this.sceneName = sceneName;
        anim.Play("FadeIn");
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}


