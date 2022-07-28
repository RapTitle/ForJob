using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Itch.Statemachine
{
    public abstract class ActionSO :ScriptableObject
    {
        public abstract void Act(StateController controller);
    }

}

