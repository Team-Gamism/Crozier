using System.Linq;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class StopReciever : MonoBehaviour, INotificationReceiver
{
    [SerializeField] PlayableDirector director;

    TimelineAsset timeline;
    TrackAsset stopTrack;

    void Start()
    {
        timeline = director.playableAsset as TimelineAsset;
        foreach (var timeline in timeline.GetOutputTracks())
        {
            if (timeline is StopTrack)
            {
                stopTrack = timeline;
            }
        }
    }

    public void OnNotify(Playable origin, INotification notification, object context)
    {
        if (notification is StopMarker stopMarker)
        {
            if (stopMarker.markerType == StopMarkerType.Resume)
                director.Pause();
            else if (stopMarker.markerType == StopMarkerType.NextMarker)
            {
                double time = NextStopMarker();
                director.Stop();
                director.time = time;
                director.Evaluate();
            }
            else if (stopMarker.markerType == StopMarkerType.End)
                Destroy(director.gameObject);
        }
    }

    public double NextStopMarker()
    {
        var markers = stopTrack.GetMarkers().OrderBy(marker => marker.time);

        foreach (var marker in markers)
        {
            if (marker.time > director.time)
            {
                director.time = marker.time;
                return marker.time;
            }
        }

        return 0;
    }


}