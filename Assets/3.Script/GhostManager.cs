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
                GameObject ghostManager = new GameObject("GhostManager");
                instance = ghostManager.AddComponent<GhostManager>();
                DontDestroyOnLoad(ghostManager);
            }
            return instance;

        }
    }

    public bool isPossessing;
    public bool isMoving;

    private IMovable currentMovable;

    public void SetMovable(IMovable newMovable)
    {
        if (currentMovable == newMovable) return;

        currentMovable = newMovable;
    }

    private void Update()
    {
        currentMovable?.Move();
    }
}