using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Fade : MonoBehaviour
{
    string sceneName;
    public GameObject introUI;

    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        if (GameManager.Instance.isIntroShown)
        {
            anim.Play("FadeOut");
            if(introUI != null)
                introUI.SetActive(false);
        }
        else
        {
            introUI.SetActive(true);
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


