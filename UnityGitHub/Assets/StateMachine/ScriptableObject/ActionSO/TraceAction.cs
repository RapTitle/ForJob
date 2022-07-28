using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Itch.Statemachine
{
    [CreateAssetMenu(menuName = "StateMachine/ActionSO/TraceAction")]
    public class TraceAction : ActionSO
    {
        public override void Act(StateController controller)
        {
            controller.enemy.TraceState();
        }
    }
}

