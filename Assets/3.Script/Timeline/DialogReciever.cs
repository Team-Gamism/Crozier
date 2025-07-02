using UnityEngine;
using UnityEngine.Playables;

public class DialogReciever : MonoBehaviour, INotificationReceiver
{
    [SerializeField] private DialogAnimator dialogAnimator;

    public void OnNotify(Playable origin, INotification notification, object context)
    {
        if (notification is DialogMarker dialogMarker && dialogAnimator != null)
        {
            var newDialog = new DialogMarkerData
            {
                Massage = dialogMarker.Message,
                PausePerLetter = dialogMarker.PausePerLetter,
                Name = dialogMarker.Name
            };

            dialogAnimator.AddDialog(newDialog);
        }
    }
}