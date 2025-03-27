using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;


public class Possess : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;
    private SpriteRenderer spriteRenderer;

    public bool isPossessing;

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void DetectPossessableObject()
    {
        Collider2D[] collider2D = Physics2D.OverlapBoxAll(transform.position, Vector3.one/10, 0f, layerMask, -1, 1);
        if (collider2D.Length >= 1)
        {
            if (collider2D[0].TryGetComponent<IPossessable>(out var entity))
            {
                spriteRenderer.enabled = false;
                isPossessing = true;
            }
        }
    }
}
