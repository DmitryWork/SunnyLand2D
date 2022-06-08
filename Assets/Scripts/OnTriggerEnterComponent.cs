using UnityEngine;
using UnityEngine.Events;

public class OnTriggerEnterComponent : MonoBehaviour
{
    [SerializeField] private UnityEvent _action;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>())
        {
            _action?.Invoke();
        }
    }
}