using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class DistributorSpawnPositions : MonoBehaviour
    {
        [field: SerializeField] public List<SpawnPosition> PlayerSpawnPositions { get; private set; }
        [field: SerializeField] public List<SpawnPosition> EnemySpawnPositions { get; private set; }
    }
}