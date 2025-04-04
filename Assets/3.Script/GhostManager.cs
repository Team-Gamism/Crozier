using UnityEngine;

public interface IMovable
{
    void Move();
}


public class GhostManager : MonoBehaviour
{
    private static GhostManager instance;
    public static GhostManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject prossessManager = new GameObject("PossessManager");
                instance = prossessManager.AddComponent<GhostManager>();
                DontDestroyOnLoad(prossessManager);
            }
            return instance;

        }
    }

    public bool isPossessing;
    public bool isMoving;

    private IMovable currentMoveable;

    public void SetMoveable(IMovable newMoveable)
    {
        if (currentMoveable == newMoveable) return;

        currentMoveable = newMoveable;
    }

    private void Update()
    {
        currentMoveable?.Move();
    }
}

