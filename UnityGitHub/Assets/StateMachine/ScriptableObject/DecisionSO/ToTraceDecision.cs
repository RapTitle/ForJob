using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Itch.Statemachine
{
    [CreateAssetMenu(menuName = "StateMachine/DecisionSO/ToTrace")]
    public class ToTraceDecision : DecisionSO  
    {
        public override bool Decide(StateController controller)
        {
            return controller.enemy.ToTrace();
        }
    }

}

