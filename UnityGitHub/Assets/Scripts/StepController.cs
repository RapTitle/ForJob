using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Users;

public class StepController : MonoBehaviour
{
    //此脚本的用处
    /*
     * 根据Actor获得相应的任务数据
     * tip:任务数据应该是DialogueData不是DialogueLine,因为我们需要对Choice进行操作
     * 将任务对话传递给UI
     * tip：人物对话应该是
     */
    
    //引用
    //角色名字
    [SerializeField] private ActorSO actor;
    //默认对话
    [SerializeField] private DialogueLineSO defaultDialogue;
    
    //储存的数据
   [SerializeField] private DialogueDataSO currDialogueData;


   

    
    //碰撞器Enter后使用
   public void SetDialogueData()
   {
       currDialogueData = QuestManager.GetInstance().InteractWithCharacter(actor);
       UIManager.GetInstance().SetData(currDialogueData);
   }


   //碰撞器在碰撞区域内运行
   public void UpdataDialogue()
   {
       //UIManager进行很对话 正常对话
       //当一段对话结束，UIManager根据Data是否有Choice进行判断
       //判断经验QuestManager进行，根据判断结果更正Data,然后此脚本根据QuestManager获得新的currDialogueData
       //UIManager继续对话 完成对话会or失败对话
   }

   private void Start()
   {
       SetDialogueData();
       UIManager.GetInstance().ShowDialogueUI();
   }

   private void Update()
   {
       if(Input.GetKeyDown(KeyCode.K))
           UIManager.GetInstance().UpdataDialogue();
   }
}
