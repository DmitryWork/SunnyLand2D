using UnityEngine;
using UnityEngine.Events;

public class OnTriggerPlayerEnterEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent _action;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _action?.Invoke();
        }
    }
}