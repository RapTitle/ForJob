using System.Collections;
using System.Collections.Generic;
using Itch.Statemachine;
using UnityEngine;

namespace Itch.Statemachine
{
    [CreateAssetMenu(menuName = "StateMachine/DecisionSO/ToIdle")]
    public class ToIdle : DecisionSO
    {
        public override bool Decide(StateController controller)
        { 
            return controller.enemy.ToIdle();
        }
    }
}

