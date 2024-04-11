using System.Collections.Generic;
using System.Collections;
using Cinemachine;
using UnityEngine;
using Game.Data;
using Zenject;

namespace Game
{
    public interface ISpawner : IInitialization<ModelSpawner>, IUpdater
    {
        public IReadOnlyList<Unit> Units { get; }
        public IReadOnlyList<Unit> LifeUnits { get; }
        public IReadOnlyList<Unit> DeadUnits { get; }
        public DiContainer DiContainer { get; }
        public Unit Player { get; }
        public Transform UnitsContant { get; }
        public ModelSpawner Model { get; }

        public void Constructor(DiContainer diContainer);
        public IEnumerator Spawn();
        public void SpawnUnit(Character character, Vector2 position);
        public void SpawnItem();
    }

    public class Spawner : ISpawner
    {
        public IReadOnlyList<Unit> Units => _units;
        public IReadOnlyList<Unit> LifeUnits => _lifeUnits;
        public IReadOnlyList<Unit> DeadUnits => _deadUnits;
        public Transform UnitsContant { get; private set; }

        private List<Unit> _units;
        private List<Unit> _lifeUnits;
        private List<Unit> _deadUnits;

        public DiContainer DiContainer { get; private set; }
        public Unit Player { get; private set; }
        public ModelSpawner Model { get; private set; }


        public Spawner(Transform unitContant)
        {
            UnitsContant = unitContant;
        }

        public void Constructor(DiContainer diContainer)
        {
            DiContainer = diContainer;
        }

        public void Init(ModelSpawner model)
        {
            Model = model;
            _units = new List<Unit>(model.Data.UnitSettings.Count);
            _lifeUnits = new List<Unit>(model.Data.UnitSettings.Count);
            _deadUnits = new List<Unit>(model.Data.UnitSettings.Count);
        }

        public IEnumerator Spawn()
        {
            if (Model == null)
            {
                Debug.LogError($"class {GetType().Name} , nullreferences in model!");
                yield return null;
            }

            WaitForSeconds wait = null;
            float waitTime = 0f;

            foreach (SpawSettingUnit spawSetting in Model.Data.UnitSettings)
            {
                wait ??= new WaitForSeconds(waitTime = spawSetting.Wait);

                if (spawSetting.WaitEnd)
                {
                    if (waitTime != spawSetting.Wait)
                        wait = new WaitForSeconds(waitTime = spawSetting.Wait);

                    yield return wait;
                }

                int rand = Random.Range(0, spawSetting.SpawnPositions.Count);
                SpawnUnit(spawSetting.Unit.Character, spawSetting.SpawnPositions[rand].transform.position);
            }

            yield return null;
        }

        public void SpawnUnit(Character character, Vector2 position)
        {
            Unit clone = GameObject.Instantiate(character.UnitPrefab, UnitsContant);
            clone.transform.position = position;
            clone.Construct(DiContainer);
            clone.Init(character);

            _units.Add(clone);
            _lifeUnits.Add(clone);

            if (clone.IsHero)
            {
                DiContainer.BindInstance<Unit>(clone).WithId("Player").AsSingle();
                Player = clone;
                DiContainer.TryResolve<CinemachineVirtualCamera>().Follow = Player.transform;
                DiContainer.TryResolve<Aim>().Init(Player);
            }
        }

        public void SpawnItem()
        {
        }

        public void OnUpdate()
        {
            for (int i = LifeUnits.Count - 1; i >= 0; i--)
            {
                LifeUnits[i].OnUpdate();
            }
        }
    }
}