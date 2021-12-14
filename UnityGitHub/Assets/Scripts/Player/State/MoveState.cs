using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : FSMState
{
   
   public MoveState(FSMSystem system)
   {
      fSMSystem = system;
      input = fSMSystem.playerInput;
   }
   
   public override void OnEnterState()
   {
      fSMSystem.playerInput.anim.SetBool("IsMoveing",true);
   }

   public override void OnUpdateState()
   {
      input.SetCurrDic();
      input.dic = input.currVelocity.normalized;
      input.dic.y = 0;
      if (input.dic != Vector3.zero)
         input.transform.forward = Vector3.Slerp(input.transform.forward,
            input.dic.normalized, 0.1f);
      input.moveSpeed = Mathf.Lerp(input.moveSpeed, input.maxSpeed, 0.01f);
      input.anim.SetFloat("MoveingSpeed",input.isRun?input.moveSpeed/input.maxSpeed:0);
      input.PlayerMove(input.currDic);
      OnChanState();
   }

   public override void OnExitState()
   {
      input.anim.SetBool("IsMoveing",false);
      // input.currDic=Vector3.zero;
      // input.currDic.y = -9.8f;

   }

   public override void OnChanState()
   {
      if (!fSMSystem.playerInput.isMove)
      {
         fSMSystem.ChangeState(StateID.Idle);
         return;
      }
      if (fSMSystem.playerInput.isJump)
      {
         fSMSystem.ChangeState(StateID.Jump);
         return;
      }
         
   }
}
