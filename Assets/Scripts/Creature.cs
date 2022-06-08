using UnityEngine;

public class Creature : MonoBehaviour
{
    protected Vector2 Direction;

    protected virtual void Update()
    {
        FlipSprite();
        SetDirection(Direction);
    }

    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }

    private void FlipSprite()
    {
        if (Direction.x != 0)
        {
            transform.localScale = new Vector2(Mathf.Sign(Direction.x), transform.localScale.y);
        }
    }
}