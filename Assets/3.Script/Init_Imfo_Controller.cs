using UnityEngine;

public class Init_Imfo_Controller : MonoBehaviour
{
    private void Start()
    {
        Init_Imfo();
    }

    void Init_Imfo()
    {
        SingleTon<GameManager>.Instance.reputation = 0;
    }
}
