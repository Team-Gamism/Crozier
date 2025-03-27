using UnityEngine;

public class EntityController : MonoBehaviour
{
    public EntitySO entitySO;

    float curHp;

    private void Start()
    {
        curHp = entitySO.maxHp;
    }


}
