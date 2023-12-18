using UnityEngine;
using Zenject;

public interface ICharacterController
{
    public Animator Animator { get; }
    public Rigidbody2D Rigidbody { get; }
    public DiContainer Container { get; }

    public void Init();
    public void OnUpdate();
}

public class CharacterController : MonoBehaviour, ICharacterController
{
    [field: SerializeField] public Animator Animator { get; protected set; }
    [field: SerializeField] public Rigidbody2D Rigidbody { get; protected set; }

    [Inject]
    public DiContainer Container { get; protected set; }

    private void Start() => Init();
    private void LateUpdate() => OnUpdate();
    public virtual void Init() { }
    public virtual void OnUpdate() { }
}
