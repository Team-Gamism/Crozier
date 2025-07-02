using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class StopMarker : Marker, INotification, INotificationOptionProvider
{
    public StopMarkerType markerType;

    [Space(20)]
    [SerializeField] bool retroative = false;
    [SerializeField] bool emitOnce = false;


    public PropertyName id => new PropertyName();
    public NotificationFlags flags => (retroative ? NotificationFlags.Retroactive : default)
        | (emitOnce ? NotificationFlags.TriggerOnce : default);
}

public enum StopMarkerType
{
    Resume,
    NextMarker,
    NoStop,
    End
}
