using UnityEngine;

public class AnimatorParametersNames : MonoBehaviour
{
    public int IsGrounded { get; private set; }
    public int IsRunning { get; private set; }
    public int YVelocity { get; private set; }

    private void Awake()
    {
        IsGrounded = Animator.StringToHash("isGrounded");
        IsRunning = Animator.StringToHash("isRunning");
        YVelocity = Animator.StringToHash("yVelocity");
    }
}