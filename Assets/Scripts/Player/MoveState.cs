using Test;
using UnityEngine;

public class MoveState : IState
{
    private Rigidbody2D _rigidbody;
    private InputAxis _input;
    private Vector2 _zero;
    private Stats _stats;

    public MoveState(Rigidbody2D rigidbody, ref InputAxis input, ref Stats stats)
    {
        _rigidbody = rigidbody;
        _input = input;
        _stats = stats;
    }

    public void Enter()
    {
    }

    public void Exit()
    {
    }

    public void Update()
    {
        Vector3 targetVelocity = new Vector2(_input.x * 10f, _rigidbody.velocity.y);
        _rigidbody.velocity = Vector2.SmoothDamp(_rigidbody.velocity, targetVelocity, ref _zero, _stats.Smoothing);
    }
}