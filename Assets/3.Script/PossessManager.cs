using UnityEngine;

public interface IMovable
{
    void Move();
}


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

    private IMovable currentMoveable;

    public void SetMoveable(IMovable newMoveable)
    {
        Debug.Log(newMoveable);
        if (currentMoveable == newMoveable) return;

        currentMoveable = newMoveable;
    }

    private void Update()
    {
        currentMoveable?.Move();
    }
}

