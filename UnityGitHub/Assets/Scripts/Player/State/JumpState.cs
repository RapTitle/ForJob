using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : FSMState
{
    private float tmp;

    public JumpState(FSMSystem system)
    {
        fSMSystem = system;
        input = system.playerInput;
    }

    public override void OnEnterState()
    { 
        input.anim.SetBool("IsAir",true);
        tmp = input.jumpDuration;
        Debug.Log("IsAir");
    }

    public override void OnUpdateState()
    {
        // input.SetCurrDic();
        input.PlayerJump();
        OnChanState();
    }

    public override void OnExitState()
    {
        //
        input.jumpDuration = tmp;
        input.currVelocity=Vector3.zero;
        input.anim.SetBool("IsAir",false);
      
       
    }

    public override void OnChanState()
    {
        if (!input.isJump && input.isMove)
        {
            fSMSystem.ChangeState(StateID.Moveing);
            return;
        }

        if (!input.isJump)
        {
            fSMSystem.ChangeState(StateID.Idle);
            return;
        }
    }
}


