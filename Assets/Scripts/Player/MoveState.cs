using Test;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using static Test.Player;

public class MoveState : IState
{
    private Rigidbody2D _rigidbody;
    private InputAxis _input;
    private Vector3 _zero;
    private Stats _stats;

    public MoveState(Rigidbody2D rigidbody, ref InputAxis input, ref Stats stats)
    {
        _rigidbody = rigidbody;
        _input = input;
        _stats = stats;
    }

    public void Enter() { }

    public void Exit() { }

    public void FixedUpdate()
    {
        if (_stats.CanMove)
        {
            //if (_stats.Dash && _stats.CanDash)
            // {
            //_rigidbody.AddForce(new Vector2(transform.localScale.x * m_DashForce, 0f));
            //StartCoroutine(DashCooldown());
            // }
            // If crouching, check to see if the character can stand up
            //if (_stats.IsDashing)
            //{
            //    _rigidbody.velocity = new Vector2(transform.localScale.x * m_DashForce, 0);
            //}
            //only control the player if grounded or airControl is turned on
            if (_stats.Grounded || _stats.AirControl)
            {
                if (_rigidbody.velocity.y < -_stats.LimitFallSpeed)
                    _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, -_stats.LimitFallSpeed);
                // Move the character by finding the target velocity
                Vector3 targetVelocity = new Vector2(_input.x * 10f, _rigidbody.velocity.y);
                // And then smoothing it out and applying it to the character
                _rigidbody.velocity = Vector3.SmoothDamp(_rigidbody.velocity, targetVelocity, ref _zero, _stats.MovementSmoothing);

                //// If the input is moving the player right and the player is facing left...
                //if (move > 0 && !m_FacingRight)
                //{
                //    // ... flip the player.
                //    Flip();
                //}
                //// Otherwise if the input is moving the player left and the player is facing right...
                //else if (move < 0 && m_FacingRight && !isWallSliding)
                //{
                //    // ... flip the player.
                //    Flip();
                //}
            }
        }

        //Vector3 targetVelocity = new Vector2(_input.x * 10f, _rigidbody.velocity.y);
        //_rigidbody.velocity = Vector2.SmoothDamp(_rigidbody.velocity, targetVelocity, ref _zero, _stats.Smoothing);
    }

    public void LateUpdate() { }

    public void Update() { }
}