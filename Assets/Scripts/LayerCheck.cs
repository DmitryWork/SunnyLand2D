using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class LayerCheck : MonoBehaviour
{
    [SerializeField] private Collider2D _groundCheck;
    [SerializeField] private LayerMask _whatIsGround;

    public bool IsTouchingGround { get; private set; }

    private void Awake()
    {
        _groundCheck = GetComponent<Collider2D>();
    }

    private void Update()
    {
        IsTouchingGround = _groundCheck.IsTouchingLayers(_whatIsGround);
    }
}