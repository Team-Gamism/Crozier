using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialEnd : MonoBehaviour
{
    [SerializeField] UI_Fade fadeUI;
    private void OnEnable()
    {
        fadeUI.FadeIn("Tutorial");
    }
}
