using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Itch.Statemachine
{
    [Serializable]
    public class Transition
    {
        public DecisionSO decision;
        public StateSO trueState;
        public StateSO falseState;
    
    }

}

