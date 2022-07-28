using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Itch.Statemachine
{
    [CreateAssetMenu(menuName = "StateMachine/DecisionSO/ToPatrol")]
    public class ToPatrolDecision : DecisionSO
    {
        public override bool Decide(StateController controller)
        {
            return controller.enemy.ToPatrol();
        }
    }

}

