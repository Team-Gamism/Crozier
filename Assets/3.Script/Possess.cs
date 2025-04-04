using UnityEngine;
using System.Linq;

public class Possess : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;
    private SpriteRenderer spriteRenderer;

    private GhostMove ghostMove;
    private PossessMove possessMove;

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        ghostMove = GetComponent<GhostMove>();
        possessMove = GetComponent<PossessMove>();
    }

    private void Start()
    {
        GhostManager.Instance.SetMoveable(ghostMove);
    }

    public void DetectPossessableObject()
    {
        Collider2D[] collider2D = Physics2D.OverlapBoxAll(transform.position, Vector3.one/10, 0f, layerMask, -1, 1);

        if (collider2D.Length > 0)
        {
            var nearest = collider2D.OrderBy(c => Vector3.Distance(transform.position, c.transform.position)).First();

            if (nearest.TryGetComponent<IPossessable>(out var possessable))
            {
                spriteRenderer.enabled = false;
                nearest.transform.SetParent(transform);

                GhostManager.Instance.isPossessing = true;
                GhostManager.Instance.SetMoveable(possessMove);
            }
        }
    }
}
