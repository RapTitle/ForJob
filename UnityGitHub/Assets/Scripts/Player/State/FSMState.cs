using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FSMState
{
    //获得状态机，有撞太极i控制状态
    private FSMSystem fSMSystem;
    public FSMState(FSMSystem system)
    {
        fSMSystem = system;
    }

    public abstract void OnEnterState();
    public abstract void OnUpdateState();
    public abstract void OnExitState();

}
