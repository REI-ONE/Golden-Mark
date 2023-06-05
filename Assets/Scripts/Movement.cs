using UnityEngine;
using System;

[Flags]
public enum MoveMode
{
    None = 0x0,
    Move = 0x2,
    Jump = 0x4,
    SitDowm = 0x8,
    Jerk = 0x10
}

public interface IMoveable
{
    public MoveMode Mode { get; }
    public Vector2 Direction { get; }
    public void OnMove(Vector2 direction);
    public void OnJump();
    public void OnSitDown(bool flag);
    public void OnJerk(bool flag);
    public void OnUpdate();
}

public class Movement : MonoBehaviour, IMoveable
{
    [SerializeField] private Rigidbody2D _body;
    [field: SerializeField] public MovementParams Params { get; private set; }

    public MoveMode Mode { get; private set; } = MoveMode.None;
    public Vector2 Direction { get; private set; }

    [Serializable]
    public class MovementParams
    {
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public float Power { get; private set; }

        public float SpeedRuntime;
        public float PowerRuntime;

        public void Init()
        {
            SpeedRuntime = Speed;
            PowerRuntime = Power;
        }
    }


    public void OnJump()
    {
        Mode |= MoveMode.Jump;
    }

    private void Jump(Vector2 direction)
    {
        _body.AddForce(Vector2.up * Params.PowerRuntime, ForceMode2D.Impulse);
        Vector2 power = _body.velocity;
        power.y = Math.Clamp(power.y, -Params.PowerRuntime, Params.PowerRuntime);
        _body.velocity = power;
        Mode &= ~MoveMode.Jump;
    }

    public void OnMove(Vector2 direction)
    {
        Direction = direction;
        Mode |= MoveMode.Move;
    }

    private void Move()
    {
        _body.AddForce(Direction * Params.SpeedRuntime, ForceMode2D.Impulse);
        Vector2 speed = _body.velocity;
        speed.x = Math.Clamp(speed.x, -Params.SpeedRuntime, Params.SpeedRuntime);
        _body.velocity = speed;
        Direction = Vector2.zero;
        Mode &= ~MoveMode.Move;
    }

    public void OnSitDown(bool flag)
    {
        if (flag)
        {
            Mode &= ~MoveMode.Jerk;
            Mode |= MoveMode.SitDowm;
        }
        else
            Mode &= ~MoveMode.SitDowm;
    }

    public void OnJerk(bool flag)
    {
        if (flag)
        {
            Mode |= MoveMode.Jerk;
        }
        else
            Mode &= ~MoveMode.Jerk;
    }

    public void OnUpdate()
    {
        if (Mode.HasFlag(MoveMode.SitDowm))
        {
            Params.SpeedRuntime = Math.Clamp(Params.SpeedRuntime, Params.Speed / 2, Params.Speed / 2);
            Params.PowerRuntime = Math.Clamp(Params.PowerRuntime, Params.Power / 2, Params.Power / 2);
        }
        else
        {
            Params.SpeedRuntime = Math.Clamp(Params.SpeedRuntime, Params.Speed, Params.Speed);
            Params.PowerRuntime = Math.Clamp(Params.PowerRuntime, Params.Power, Params.Power);

            if (Mode.HasFlag(MoveMode.Jerk))
                Params.SpeedRuntime = Math.Clamp(Params.SpeedRuntime, Params.Speed * 2, Params.Speed * 2);
            else
                Params.SpeedRuntime = Math.Clamp(Params.SpeedRuntime, Params.Speed, Params.Speed);
        }


        if (Mode.HasFlag(MoveMode.Jump))
            Jump(Vector2.up);

        if (Mode.HasFlag(MoveMode.Move))
            Move();
    }
}