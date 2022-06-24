using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class LayerCheck : MonoBehaviour
{
    [SerializeField] private Collider2D _groundCheck;
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private LayerMask _whatIsEnemyHead;

    public bool IsTouchingGround { get; private set; }
    public bool IsTouchingEnemyHead { get; private set; }

    private void Awake()
    {
        _groundCheck = GetComponent<Collider2D>();
    }

    private void Update()
    {
        IsTouchingGround = _groundCheck.IsTouchingLayers(_whatIsGround);
        IsTouchingEnemyHead = _groundCheck.IsTouchingLayers(_whatIsEnemyHead);
    }
}