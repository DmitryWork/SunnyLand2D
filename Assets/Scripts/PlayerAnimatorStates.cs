using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Player), typeof(Rigidbody2D), m_Type0 = typeof(AnimatorIdParameters))]
public class PlayerAnimatorStates : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Player _player;

    private AnimatorIdParameters _animatorId;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _animatorId = GetComponent<AnimatorIdParameters>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        _animator.SetFloat(_animatorId.YVelocityKey, _rigidbody.velocity.y);
        _animator.SetBool(_animatorId.IsRunningKey, _player.IsRunning);
        _animator.SetBool(_animatorId.IsGroundedKey, _player.IsGrounded);
    }
}