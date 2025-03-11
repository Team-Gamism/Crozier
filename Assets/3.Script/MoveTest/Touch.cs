using UnityEngine;
using UnityEngine.Events;

public class Touch : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
            TouchRaycast(Input.mousePosition);
    }
    private void TouchRaycast(Vector3 pos)
    {
        Ray ray = Camera.main.ScreenPointToRay(pos);
        RaycastHit2D raycast = Physics2D.Raycast(ray.origin, ray.direction, 1, layerMask, -1, 1);
        if (raycast)
        {
            if (raycast.collider.TryGetComponent<ITouchable>(out var entity))
                entity.Clicked();
        }
    }
}
