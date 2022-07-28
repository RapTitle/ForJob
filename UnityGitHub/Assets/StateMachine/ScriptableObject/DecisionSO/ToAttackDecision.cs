using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Itch.Statemachine
{
    [CreateAssetMenu(menuName = "StateMachine/DecisionSO/ToAttack")]
    public class ToAttackDecision : DecisionSO
    {
        public override bool Decide(StateController controller)
        {
            return controller.enemy.ToAttack();
        }
    }

}
