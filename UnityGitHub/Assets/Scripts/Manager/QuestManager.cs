using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class QuestSaveData
{
    public int currQuestLineNum=0;
    public int currQuestNum=0;
    public int currStepNum=0;
}

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
   private bool isThis=false;
    
    //索引
    public QuestSaveData saveData=new QuestSaveData();
    public int currQuestLineNum=0;
    public int currQuestNum=0;
    public int currStepNum=0;
   
    
    //强制要求线性

    //初始化


    private void OnEnable()
    {
        WithJson.GetInstance.LoadFromFile<QuestSaveData>(saveData, "/Json/QuestData.json");
        if (saveData != default)
        {
             currQuestNum = saveData.currQuestNum;
             currQuestLineNum = saveData.currQuestLineNum;
             currStepNum = saveData.currStepNum;
        }
        
        //读取存储的任务
        

    }

    private void Start()
    {
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

    
    //正常对话到完成对话
    private void NormalToFinish()
    {
        currDialogueData = currStep.finishDialogueData;
       
    }
    //正常对话到失败对话
    private void NormalToFail()
    {
        currDialogueData = currStep.failDialogueData;
    }

    //失败到正常
    private void FailToNormal()
    {
        currDialogueData = currStep.normalDialogueData;
    }


    
    public DialogueDataSO InteractWithCharacter(ActorSO actor)
    {

        if (currStep.actor == actor && !currStep.isDone)
        {
            isThis = true;
            return currDialogueData;
        }

      
        else
        {
            isThis = false;
            return null;
        }

    }


    public void Check()
    {
        if (currStep.isDone||!isThis)
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
            case  StepType.Give:
                Debug.Log("GiverOK");
                playerInventory.AddItem(currStep.itemStack.item,currStep.itemStack.amount);
                NormalToFinish();
                UIManager.GetInstance().SetData(currDialogueData);
                currStep.type = StepType.Dialogue;
                UIManager.GetInstance().UpdataDialogue();
                break;



        }
    }

    public void UnCheck()
    {
        if (currStep.isDone||!isThis)
            return;
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
        currStepNum++; 
       
        //此任务步骤完成，切换到下一个任务
        if (currStepNum >= currQuest.steps.Count)
        {
            Debug.Log("ChangeQuest");
           ChangeQuest();
           return;
        }
       Save();
      //未完成，则跳转之下一个Step
        currStep = currQuest.steps[currStepNum];
        currDialogueData = currStep.normalDialogueData;
        currType = currStep.type;
  
    }

    private void ChangeQuest()
    {
        currQuestNum++;
        if (currQuestNum >= currQuestLine.questLines.Count)
        {
            ChangeQuestLine();
            return;
        }
        currQuest = currQuestLine.questLines[currQuestNum];
        currStepNum = 0;
        currStep = currQuest.steps[currStepNum];
    }

    private void ChangeQuestLine()
    {
        currQuestLineNum++;
        if (currQuestLineNum >= questLines.Count)
        {
           Win();
           return;
          
        }

        currQuestLine = questLines[currQuestLineNum];
        currQuestNum = 0;

    }

    private void Save()
    {
        Debug.Log("Save");
        saveData.currQuestNum = currQuestNum;
        saveData.currQuestLineNum = currQuestLineNum;
        saveData.currStepNum = currStepNum;
        WithJson.GetInstance.SaveToJson(saveData,"/Json/QuestData.json");
    }

    private void Win()
    {
        currDialogueData = null;
        Debug.Log("You Win!");
     

    }
    
    
    

   

   



}
