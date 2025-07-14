using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class SoundMarker : Marker, INotification, INotificationOptionProvider
{
    public AudioClip clip;

    [Space(20)]
    [SerializeField] bool retroative = false;
    [SerializeField] bool emitOnce = false;


    public PropertyName id => new PropertyName();
    public NotificationFlags flags => (retroative ? NotificationFlags.Retroactive : default)
        | (emitOnce ? NotificationFlags.TriggerOnce : default);
}
