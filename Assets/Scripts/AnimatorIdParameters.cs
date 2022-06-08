using UnityEngine;

public class AnimatorIdParameters : MonoBehaviour
{
    public int IsGroundedKey { get; private set; }
    public int IsRunningKey { get; private set; }
    public int YVelocityKey { get; private set; }

    private void Awake()
    {
        IsGroundedKey = Animator.StringToHash("isGrounded");
        IsRunningKey = Animator.StringToHash("isRunning");
        YVelocityKey = Animator.StringToHash("yVelocity");
    }
}