using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Itch.Statemachine
{
    
[CreateAssetMenu(menuName = "StateMachine/ActionSO/PatroAction")]
public class PatrolAction : ActionSO
{
   

    public override void Act(StateController controller)
    {
        
        //巡逻动作
        controller.enemy.PatrolState();
       
    }
}

}
