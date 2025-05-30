using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectButtonTextUI : MonoBehaviour
{
    Image image;
    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void MouseEnter()
    {
        image.color = new Color(0, 0, 0, 0.5f);
    }
    public void MouseExit()
    {
        image.color = new Color(0, 0, 0, 0f);
    }
}
