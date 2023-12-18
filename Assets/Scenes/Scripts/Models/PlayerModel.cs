using System;

[Serializable]
public struct PlayerData
{
    public float HP;
    public float Speed;
}

[Serializable]
public class PlayerModel : Model<PlayerData>
{
    public override PlayerData Copy()
    {
        PlayerData data = new();
        data.HP = Data.HP;
        data.Speed = Data.Speed;
        return data;
    }
}