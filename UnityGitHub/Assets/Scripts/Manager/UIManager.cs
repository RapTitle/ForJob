using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    //仅实现基础显示，其他的删选等交给StepController
    
    
    //引用对象
    [SerializeField] private DialogueUICon dialogueUICon;

    [Header("控制")] 
    [SerializeField] private float textWait;

    private WaitForSeconds textWaitTime;
    private int currline = 0;

    private DialogueDataSO dialogueData;

    private Coroutine setDialogueCoroutine;


    protected override void Awake()
    {
        base.Awake();
        textWaitTime = new WaitForSeconds(textWait);


    }

    private void Start()
    {
        dialogueUICon.HideDialogueUI();
    }

    public void ShowDialogueUI()
    {
        dialogueUICon.ShouDialogueUI();
    }


    public void SetData(DialogueDataSO data)
    {
      
        dialogueData = data;
    }


    public void UpdataDialogue()
    {  
        if (currline >= dialogueData.dialogueLine.dialogues.Count)
        {
            Debug.Log("对话完成");
            return;
        }
        SetDialogue(dialogueData.dialogueLine.dialogues[currline]);
    }


    public void SetDialogue(string dialogue)
    {
        if (setDialogueCoroutine != null)
        {
            StopCoroutine(setDialogueCoroutine);
            dialogueUICon.SetDialogue(dialogue);
            currline += 1;
            setDialogueCoroutine = null;
            CheckDialogue();
            return;
        } 
        setDialogueCoroutine = StartCoroutine(SetDialogueCoroutine(dialogue));
    }

    IEnumerator SetDialogueCoroutine(string dialogue)
    {
        dialogueUICon.ClearText();
        foreach (char d in dialogue)
        {
            dialogueUICon.SetDialogue(d);
            yield return textWaitTime;
        }

        setDialogueCoroutine = null;
        CheckDialogue();
        currline += 1;
    }


    
    /// <summary>
    /// 判断对话是否含有选择，若含有选择，则根据选择跳转完成对话和失败对话，没有选择则可以直接跳转下一个Step
    /// </summary>
    private void CheckDialogue()
    {
        if (currline < dialogueData.dialogueLine.dialogues.Count)
            return;
        if (dialogueData.choiceButton != null)
        {
            dialogueUICon.ShowButton();
            dialogueUICon.SetButtonYesText(dialogueData.choiceButton.choiceButtons[0].choiceName);
            dialogueUICon.SetButtonNoText(dialogueData.choiceButton.choiceButtons[1].choiceName);
        }
        //如果没有Button,说明可以直接检擦
        else
        {
            //QuestManager.GetInstance().Check();
        }
    }

    private void HideButton()
    {
        dialogueUICon.HideButton();
    }
}
