using Test;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using static Test.Player;

public class JumpState : IState
{
    private Rigidbody2D _rigidbody;
    private InputAxis _input;
    private Stats _stats;
    private Animator _animator;

    public JumpState(Rigidbody2D rigidbody, Animator animator, ref InputAxis input, ref Stats stats)
    {
        _rigidbody = rigidbody;
        _animator = animator;
        _input = input;
        _stats = stats;
    }

    public void Enter()
    {
        if (_stats.Grounded)
        {
            _animator?.SetBool("IsJumping", true);
            _animator?.SetBool("JumpUp", true);
            _stats.Grounded = false;
            _rigidbody.AddForce(new Vector2(0f, _stats.JumpForce));
            _stats.CanDoubleJump = true;
            //particleJumpDown.Play();
            //particleJumpUp.Play();
        }
        else if (!_stats.Grounded && _stats.CanDoubleJump)
        {
            _stats.CanDoubleJump = false;
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
            _rigidbody.AddForce(new Vector2(0f, _stats.JumpForce / 1.2f));
            //_animator?.SetBool("IsDoubleJumping", true);
        }
    }

    public void Exit() { }

    public void FixedUpdate() { }

    public void LateUpdate() { }

    public void Update() { }
}