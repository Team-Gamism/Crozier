using UnityEngine;

public class Dice : MonoBehaviour, ITouchable
{
    public int num;
    public void Clicked()
    {
        if (!move.instance.isMoving)
        {
            move.instance.MoveButton(num);
            Destroy(gameObject);
        }
    }
}
