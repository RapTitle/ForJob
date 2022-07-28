using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Itch.Statemachine
{
   [CreateAssetMenu(menuName = "StateMachine/StateSO")]
   [SerializeField]
   public class StateSO : ScriptableObject
   {
      public ActionSO[] actions;
      public Transition[] transitions;
      
     
   
   
   
      public void UpdateState(StateController controller)
      {
         
         DoActions(controller);
         CheckTransition(controller); 
        
      }
   
      private void DoActions(StateController con)
      {
         for (int i = 0; i < actions.Length; i++)
         {
            actions[i].Act(con);
         }
      }
   
      private void CheckTransition(StateController con)
      {
         
         //为什么要判断true和false
         /*
          * 假如敌人进入了一个蓄力状态，此状态有两种
          * 1.成功
          * 2.失败
          * 每一种都对应一种状态。
          * 
          */
         
         for (int i = 0; i < transitions.Length; i++)
         {
         
            bool isChange = transitions[i].decision.Decide(con);
            if(isChange)
               con.TransitionToState(transitions[i].trueState);
            else
            {
               con.TransitionToState(transitions[i].falseState);
            }
         }
      }
   }

}

