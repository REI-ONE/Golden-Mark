using System.Collections;
using Test;
using Unity.VisualScripting;
using UnityEngine;
using static Test.Player;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class DashState : IState
{
    private Rigidbody2D _rigidbody;
    private InputAxis _input;
    private Test.Player _player;
    private Stats _stats;

    public DashState(Test.Player player, Rigidbody2D rigidbody, ref InputAxis input, ref Stats stats)
    {
        _player = player;
        _rigidbody = rigidbody;
        _input = input;
        _stats = stats;
    }

    public void Enter()
    {
        if (_stats.CanDash)
        {
            _player.StartCoroutine(DashCooldown());
            _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
            //_rigidbody.AddForce(new Vector2(_rigidbody.transform.localScale.x * _stats.DashForce, 0f));
        }
    }

    public void Exit()
    {
        //_rigidbody.velocity = Vector2.zero;
    }

    public void FixedUpdate()
    {
        if (!_stats.CanMove) return;

        if (_stats.IsDashing)
            _rigidbody.velocity = new Vector2(_rigidbody.transform.localScale.x * _stats.DashForce, _rigidbody.velocity.y);
    }

    public void Update() { }

    public void LateUpdate() { }

    private IEnumerator DashCooldown()
    {
        //animator.SetBool("IsDashing", true);
        _stats.CanDash = false;
        _stats.IsDashing = true;
        yield return new WaitForSeconds(_stats.DashTime);
        _stats.IsDashing = false;
        _rigidbody.velocity = Vector2.zero;
        yield return new WaitForSeconds(_stats.DashCooldown);
        _stats.CanDash = true;
    }
}