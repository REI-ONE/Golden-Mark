using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Game.Data;

namespace Game.StateMachine.State
{
    public class UnitStateAttack : UnitStateIdle
    {
        public UnitStateAttack(UnitDataBox data) : base(data)
        {
        }
    }
}