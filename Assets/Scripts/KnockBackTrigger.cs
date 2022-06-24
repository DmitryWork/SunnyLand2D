using UnityEngine;

public class KnockBackTrigger : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            player.KnockBack(transform);
        }
    }
}