using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "QuestLines/Quests/Step")]
[Serializable]
public class StepSO : ScriptableObject
{
    public ActorSO actor;
    //任务接取对话
    public DialogueDataSO normalDialogueData;
    //任务完成对话
    public DialogueDataSO finishDialogueData;
    //任务失败对话
    public DialogueDataSO failDialogueData;
    //根据Type触发不同事件
    public StepType type;
    //事件所需物品
    public ItemStack itemStack;
    //是否完成
    public bool isDone;
}
