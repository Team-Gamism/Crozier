using UnityEngine;

public class Dice : MonoBehaviour, ITouchable
{
    public int num;
    public void Clicked()
    {
        if (!Move.instance.isMoving)
        {
            Move.instance.MoveButton(num);
            Destroy(gameObject);
        }
    }
}
