using Test;
using UnityEngine;
using static Test.Player;

public class MoveState : IState
{
    private Rigidbody2D _rigidbody;
    private InputAxis _input;
    private Vector3 _velocity;
    private Stats _stats;

    public MoveState(Rigidbody2D rigidbody, ref InputAxis input, ref Stats stats)
    {
        _rigidbody = rigidbody;
        _input = input;
        _stats = stats;
    }

    public void Enter() { }

    public void Exit()
    {
        float smoothing = _stats.Grounded ? _stats.MovementSmoothing : _stats.AirControlSmoothing;
        Vector3 targetVelocity = new Vector2(0, _rigidbody.velocity.y);
        _rigidbody.velocity = Vector3.SmoothDamp(_rigidbody.velocity, targetVelocity, ref _velocity, smoothing);
    }

    public void FixedUpdate()
    {
        if (_stats.CanMove)
        {
            if (_stats.Grounded || _stats.AirControl)
            {
                if (_rigidbody.velocity.y < -_stats.LimitFallSpeed)
                    _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, -_stats.LimitFallSpeed);

                Vector3 targetVelocity = new Vector2(_input.x * _stats.MovementSpeed, _rigidbody.velocity.y);
                _rigidbody.velocity = Vector3.SmoothDamp(_rigidbody.velocity, targetVelocity, ref _velocity, _stats.MovementSmoothing);

                if (_input.x > 0 && !_stats.FacingRight)
                    Flip();
                else if (_input.x < 0 && _stats.FacingRight)
                    Flip();
            }
        }
    }

    public void LateUpdate() { }

    public void Update() { }

    private void Flip()
    {
        _stats.FacingRight = !_stats.FacingRight;

        Vector3 theScale = _rigidbody.transform.localScale;
        theScale.x *= -1;
        _rigidbody.transform.localScale = theScale;
    }
}