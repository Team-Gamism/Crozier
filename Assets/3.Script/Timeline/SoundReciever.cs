using UnityEngine;
using UnityEngine.Playables;

public class SoundReciever : MonoBehaviour, INotificationReceiver
{
    [SerializeField] AudioSource audioSource;

    public void OnNotify(Playable origin, INotification notification, object context)
    {
        if (notification is SoundMarker soundMarker)
        {
            audioSource.clip = soundMarker.clip;
            audioSource.Play();
        }
    }
}
