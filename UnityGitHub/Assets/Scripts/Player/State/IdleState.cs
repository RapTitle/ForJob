using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : FSMState
{
    public IdleState(FSMSystem system)
    {
        fSMSystem = system;
        input = fSMSystem.playerInput;
    }

    //进入待机状态
    public override void OnEnterState()
    {
        
    }
    
    //待机状态的运行
    public override void OnUpdateState()
    {
        input.PlayerIdle();
        OnChanState();
    }

    public override void OnExitState()
    {
       
    }

    public override void OnChanState()
    {
        if (fSMSystem.playerInput.isMove)
        {
            fSMSystem.ChangeState(StateID.Moveing);
            return;
        }

        if (fSMSystem.playerInput.isJump)
        {
            fSMSystem.ChangeState(StateID.Jump);
            input.currDic=Vector2.zero;
            return;
        }
            
    }
}
