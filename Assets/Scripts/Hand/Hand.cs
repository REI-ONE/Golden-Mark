using UnityEngine;
using Game.Data;
using System;

namespace Game
{
    public interface IHand : IInitialization<Unit>, IUpdater
    {
        public Unit Owner { get; }
        public bool Empty { get; }
        public Transform Anchor { get; }
        public ItemHand ItemHand { get; }

        public void Set(SOItem itemHand);
        public void Replice(SOItem hand);
        public void Destroy();
    }

    [Serializable]
    public class Hand : IHand
    {
        [field: SerializeField] public Unit Owner { get; private set; }
        [field: SerializeField] public Transform Anchor { get; private set; }
        [field: SerializeField] public ItemHand ItemHand { get; private set; }

        public bool Empty => ItemHand == null;

        public void Init(Unit data)
        {
            Owner = data;
        }

        public void Set(SOItem itemHand)
        {
            if (itemHand == null)
                return;

            ItemHand = GameObject.Instantiate(itemHand.PrefabHand, Anchor);
            ItemHand.Init(itemHand);
            ItemHand.SetOwner(Owner);
        }

        public void Replice(SOItem hand)
        {
            Destroy();
            Set(hand);
        }

        public void Destroy()
        {
            GameObject.Destroy(ItemHand.gameObject);
            ItemHand = null;
        }

        public void OnUpdate()
        {
            ItemHand?.OnUpdate();
        }
    }
}