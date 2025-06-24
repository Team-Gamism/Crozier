using TMPro;
using UnityEngine;

public class UI_Ending : MonoBehaviour
{
   [SerializeField] UI_Fade fadeUI;

    TextMeshProUGUI title;
    TextMeshProUGUI explain;

    private void Start()
    {
        title = Util.FindChild<TextMeshProUGUI>(gameObject,"Title",true);
        explain = Util.FindChild<TextMeshProUGUI>(gameObject,"Explain",true);

        if(SingleTon<GameManager>.Instance.reputation >= 80)
        {
            title.text = "명예로운 재판관 엔딩";
            explain.text = "당신은 정의롭고 신중한 재판관이었다.\n무고한 생명을 존중하며 시민들의 존경을 받았다.\n당신의 이름은 오랫동안 전설로 남을 것이다";
        }
        else if(SingleTon<GameManager>.Instance.reputation >= 50 && SingleTon<GameManager>.Instance.reputation <= 79)
        {
            title.text = "평범한 재판관 엔딩";
            explain.text = "당신은 무난히 재판관 임무를 수행했다.\n때로는 서둘렀지만, 도시의 질서는 유지되었다.\n무고한 이의 죽음도 있었으나 큰 혼란은 없었다.\n";
        }
        else
        {
            title.text = "불신받는 재판관 엔딩";
            explain.text = "당신의 판결은 신뢰를 잃었다.\n무고한 생명이 희생되었고, 시민들은 당신을 의심했다.\n재판관의 권위는 크게 흔들렸다.\n";
        }
    }

    public void GoHome()
    {
        SingleTon<GameManager>.Instance.isStartedNewGame = false;
        fadeUI.FadeIn("MainScene");
    }
}
