using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    [SerializeField] private float followSpeed;

    void Start()
    {
        player = GameObject.Find("Player").transform;
    }


    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, 
            new Vector3(player.position.x, player.position.y, -10f), Time.deltaTime * followSpeed);
    }
}
