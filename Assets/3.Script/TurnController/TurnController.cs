using UnityEngine;

public class TurnController : MonoBehaviour
{
    public static TurnController Instance { get { return instance; }}
    static TurnController instance;

    private void Awake()
    {
        instance = this;
    }

    void ChangeTurn()
    {

    }
}
