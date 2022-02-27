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
   [SerializeField] private StepSO currStep;
   [SerializeField] private DialogueDataSO currDialogueData;
   [SerializeField] private InventorySO playerInventory;

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
        
        if (currStep.actor == actor&&!currStep.isDone)
            return currDialogueData;
        else
        {
            return null;
        }

    }


    public void Check()
    {
        if (currStep.isDone)
            return;
        switch (currStep.type)
        {
            case StepType.None:
                currStep.type = currType;
                FailToNormal();
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
                Debug.Log("CheckOK");
                if (playerInventory.ItemContains(currStep.itemStack))
                {
                  
                    NormalToFinish();
                    playerInventory.Remove(currStep.itemStack.item,currStep.itemStack.amount);
                    UIManager.GetInstance().SetData(currDialogueData);
                    currStep.type = StepType.Dialogue;
                    UIManager.GetInstance().UpdataDialogue();
                }
                else
                {
                    NormalToFail();
                    UIManager.GetInstance().SetData(currDialogueData);
                    currStep.type = StepType.None;
                    UIManager.GetInstance().UpdataDialogue();
                    

                }
                
                  
                break;



        }
    }

    public void UnCheck()
    {
        NormalToFail();
        UIManager.GetInstance().SetData(currDialogueData);
        currStep.type = StepType.None;
        UIManager.GetInstance().UpdataDialogue();
        FailToNormal();
    }

    //当完成一个Step时，应该将此Step的isDone改为true并切换至下一个Step,
    public void ChangeStep()
    {
       
        currStep.type = currType;
        currStep.isDone = true;
        currStepNum++;
        if (currStepNum >= currQuest.steps.Count)
            return;
        currStep = currQuest.steps[currStepNum];
        currDialogueData = currStep.normalDialogueData;
        currType = currStep.type;

    }
    
    
    

   

   



}
