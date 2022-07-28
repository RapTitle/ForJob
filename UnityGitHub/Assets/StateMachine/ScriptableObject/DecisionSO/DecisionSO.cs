using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Itch.Statemachine
{
    public abstract class DecisionSO : ScriptableObject
    {
        public abstract bool Decide(StateController controller);
    
    }

}

