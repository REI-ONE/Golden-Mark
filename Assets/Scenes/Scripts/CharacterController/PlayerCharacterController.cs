using UnityEngine;

public class PlayerCharacterController : CharacterController
{
    [SerializeField] private PlayerModelSO _data;
    public Model<PlayerData> Model { get; private set; }

    private Vector3 _rotate;
    private PauseObject _pauseObject;

    public override void Init()
    {
        base.Init();
        Model = new();
        Model.Set(_data.Model.Copy());
        _pauseObject = Container.TryResolve<PauseObject>();
    }

    public void Idle()
    {
        Animator.SetInteger("index", 0);
        Rigidbody.velocity = Vector2.right * 0;
    }

    public void Walk() => Move(1, 1);
    public void Run() => Move(2f);

    public void Move(float multyplayer = 1f, int index = 2)
    {
        Animator.SetInteger("index", index);
        Rigidbody.velocity = Vector2.right * Input.GetAxis("Horizontal") * (Model.Data.Speed * multyplayer) * Time.deltaTime;
    }

    public void Rotate()
    {
        _rotate = transform.localScale;

        if (Input.GetAxis("Horizontal") > .1f && transform.localScale.x < 0)
            _rotate.x = 1;
        else if (Input.GetAxis("Horizontal") < .1f && transform.localScale.x > 0)
            _rotate.x = -1;
        //else
        //    _rotate = Vector3.one;

        transform.localScale = _rotate;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if (_pauseObject.Active)
        {
            Idle();
            return;
        }

        if (Input.GetAxis("Horizontal") != 0f && Input.GetKey(KeyCode.LeftShift))
        {
            Rotate();
            Run();
        }
        else if (Input.GetAxis("Horizontal") != 0f)
        {
            Rotate();
            Walk();
        }
        else
        {
            Idle();
        }
    }
}