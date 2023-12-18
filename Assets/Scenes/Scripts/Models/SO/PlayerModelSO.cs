using UnityEngine;

[CreateAssetMenu(menuName = "Models/Player")]
public class PlayerModelSO : ScriptableObject
{
    [field: SerializeField] public PlayerModel Model { get; private set; }
}