using System.Collections.Generic;
using System;

namespace Game
{
    [Serializable]
    public struct SpawSettingUnit
    {
        public Unit Unit;
        public float Wait;
        public bool WaitEnd;
        public List<SpawnPosition> SpawnPositions;
    }

    [Serializable]
    public struct SpawnerData
    {
        public List<SpawSettingUnit> UnitSettings;
    }

    [Serializable]
    public class ModelSpawner : Model<SpawnerData>
    {
    }
}