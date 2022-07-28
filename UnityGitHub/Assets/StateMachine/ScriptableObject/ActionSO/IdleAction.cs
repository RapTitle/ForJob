using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Itch.Statemachine
{
    [CreateAssetMenu(menuName = "StateMachine/ActionSO/IdleAction")]
    public class IdleAction : ActionSO
    {
        public override void Act(StateController controller)
        {
            controller.enemy.IdleState();
        }
    }
}

