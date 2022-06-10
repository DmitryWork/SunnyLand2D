using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Player), typeof(Rigidbody2D), m_Type0 = typeof(AnimatorParametersNames))]
public class PlayerAnimatorStates : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Player _player;

    private AnimatorParametersNames _parameterName;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _parameterName = GetComponent<AnimatorParametersNames>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        _animator.SetFloat(_parameterName.YVelocity, _rigidbody.velocity.y);
        _animator.SetBool(_parameterName.IsRunning, _player.IsRunning);
        _animator.SetBool(_parameterName.IsGrounded, _player.IsGrounded);
    }
}