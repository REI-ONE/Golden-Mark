using UnityEngine;
using System;

namespace Game.Interactables
{
    public interface IInterractable
    {
        public Type Type { get; }
    }

    [RequireComponent(typeof(BoxCollider2D))]
    public abstract class Interractable : MonoBehaviour, IInterractable
    {
        public Type Type => GetType();
    }
}