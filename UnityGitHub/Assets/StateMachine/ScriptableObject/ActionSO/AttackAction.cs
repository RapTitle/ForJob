using System.Collections;
using System.Collections.Generic;
using Itch.Statemachine;
using UnityEngine;

namespace Itch.Statemachine
{
    [CreateAssetMenu(menuName = "StateMachine/ActionSO/AttackAction")]
    public class AttackAction : ActionSO
    {
        public override void Act(StateController controller)
        {
            controller.enemy.AttackState();
        }
    }

}
