using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Menu : MonoBehaviour
{
    public void Resume()
    {
        gameObject.SetActive(false);
    }

    public void Setting()
    {
        //설정 UI 띄우기
    }

    public void Home()
    {
        SceneManager.LoadScene(0);
    }
}
