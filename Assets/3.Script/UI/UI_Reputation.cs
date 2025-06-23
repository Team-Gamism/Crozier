using System.Collections;
using TMPro;
using UnityEngine;

public class UI_Reputation : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI reputationText;

    private void Start()
    {
        reputationText = Util.FindChild<TextMeshProUGUI>(gameObject,"Reputation",true);
        StartCoroutine(UpdateReputation());
    }

    IEnumerator UpdateReputation()
    {
        while (true)
        {
            yield return null;
            reputationText.text = "평판 : " + $"{SingleTon<GameManager>.Instance.reputation}";
        }
    }
}
