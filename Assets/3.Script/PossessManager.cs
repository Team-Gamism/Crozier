using UnityEngine;

public class PossessManager : MonoBehaviour
{
    private static PossessManager instance;
    public static PossessManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject prossessManager = new GameObject("PossessManager");
                instance = prossessManager.AddComponent<PossessManager>();
                DontDestroyOnLoad(prossessManager);
            }
            return instance;

        }
    }

    public bool isPossessing;
}