using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    //仅实现基础显示，其他的删选等交给StepController
    
    
    //引用对象
    [SerializeField] private DialogueUICon dialogueUICon;
    [SerializeField] private InventoryUICon inventoryUICon;
    [SerializeField] private GameObject gameMenu;
    [SerializeField] private GameObject gameInteract;

    [Header("控制")] 
    [SerializeField] private float textWait;

    private WaitForSeconds textWaitTime;
    private int currline = 0;

   [SerializeField] private DialogueDataSO dialogueData;

    private Coroutine setDialogueCoroutine;


    protected override void Awake()
    {
        base.Awake();
        textWaitTime = new WaitForSeconds(textWait);


    }

    private void Start()
    {
       HideDialogueUI();
       HideInventoryUI();
       HideInteract();
        
    }

    public void ShowInventoryUI()
    {
        HideInteract();
        inventoryUICon.ShowInventoryUI();
    }

    public void HideInventoryUI()
    {
        inventoryUICon.HideInventoryUI();
    }

    public bool isShowInventory()
    {
        return inventoryUICon.gameObject.activeSelf;
    }
    
    public void ShowDialogueUI()
    {
        HideInteract();
        dialogueUICon.ShouDialogueUI();
    }

    public void HideDialogueUI()
    {
        dialogueUICon.HideDialogueUI();

    }
    private void HideButton()
    {
        dialogueUICon.HideButton();
    }

    public void ShowMenu()
    {
        gameMenu.SetActive(true);
    }

    public void HideMenu()
    {
        gameMenu.SetActive(false);
    }

    public bool isMenuActive()
    {
        return gameMenu.activeSelf;
    }

    public void ShowInteract(string name)
    {
        gameInteract.SetActive(true);
        gameInteract.GetComponentInChildren<Text>().text = name;
    }

    public void HideInteract()
    {
        gameInteract.SetActive(false);
    }

    public void SetData(DialogueDataSO data)
    {
        HideButton();
        dialogueData = data;
        currline = 0;
    }

    public void SetData(DialogueLineSO dialogueLine, ChoiceDataSO choice = null)
    {
        HideButton();
        dialogueData = new DialogueDataSO(dialogueLine, choice);
        currline = 0;
    }


    public void UpdataDialogue()
    {  
        if (currline >= dialogueData.dialogueLine.dialogues.Count)
        {
            if (dialogueData.choiceButton == null)
                HideDialogueUI(); 
            
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
        currline += 1;
        CheckDialogue();
       
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
            QuestManager.GetInstance().Check();
        }
    }


}
