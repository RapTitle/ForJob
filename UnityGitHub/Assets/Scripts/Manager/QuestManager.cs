using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : Singleton<QuestManager>
{
    //数据引用
    [SerializeField] private List<QuestLineSO> questLines;
    
    //数据存储
    private QuestLineSO currQuestLine;
    private QuestSO currQuest;
    private StepSO currStep;
   [SerializeField] private DialogueDataSO currDialogueData;

   private StepType currType;
    
    //索引
    private int currQuestLineNum=0;
    private int currQuestNum=0;
    private int currStepNum=0;
   
    
    //强制要求线性

    //初始化
    protected override void Awake()
    {
        base.Awake();
        StartQuestLine();
    }

    private void StartQuestLine()
    {
        currQuestLine = questLines[currQuestLineNum];
        currQuest = currQuestLine.questLines[currQuestNum];
        currStep = currQuest.steps[currStepNum];
        currDialogueData = currStep.normalDialogueData;
        currType = currStep.type;
    }

    private void NormalToFinish()
    {
        currDialogueData = currStep.finishDialogueData;
    }

    private void NormalToFail()
    {
        currDialogueData = currStep.failDialogueData;
    }

    private void FailToNormal()
    {
        currDialogueData = currStep.normalDialogueData;
    }


 
    public DialogueDataSO InteractWithCharacter(ActorSO actor)
    {
        
        Debug.Log("Interact");
        if (currStep.actor == actor)
            return currDialogueData;
        else
        {
            return null;
        }

    }


    public void Check()
    {
        switch (currStep.type)
        {
            case StepType.None:
                break;
            case StepType.Dialogue:
                ChangeStep();
                break;
            case StepType.Accept:
                NormalToFinish();
                currStep.type = StepType.Dialogue;
                UIManager.GetInstance().SetData(currDialogueData);
                UIManager.GetInstance().UpdataDialogue();
                break;
            case StepType.Check:
                break;



        }
    }

    //当完成一个Step时，应该将此Step的isDone改为true并切换至下一个Step,
    public void ChangeStep()
    {
        if (currStepNum == currQuest.steps.Count - 1)
            return;
        currStep.type = currType;
        currStep.isDone = true;
        currStepNum++;
        currStep = currQuest.steps[currStepNum];
        currType = currStep.type;

    }
    
    
    

   

   



}
