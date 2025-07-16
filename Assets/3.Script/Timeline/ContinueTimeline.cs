using UnityEngine;
using UnityEngine.Playables;

public class ContinueTimeline : MonoBehaviour
{

    [SerializeField]
    PlayableDirector director;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            director.Resume();
        }
    }
}
