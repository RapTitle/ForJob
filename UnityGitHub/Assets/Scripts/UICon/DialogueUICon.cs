using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogueUICon : MonoBehaviour
{
    [SerializeField] private Text dialogueTxt;
    [SerializeField] private Button buttonYes;
    [SerializeField] private Button buttonNo;
    private Text buttonTextYes;
    private Text buttonTextNo;
    
    // private UnityAction onYesEvent=delegate {  };
    // private UnityAction onNoEvent=delegate {  };

    private void Start()
    {
        // buttonYes.onClick.AddListener();
        buttonTextYes = buttonYes.GetComponentInChildren<Text>();
        buttonTextNo = buttonNo.GetComponentInChildren<Text>();
        buttonYes.gameObject.SetActive(false);
        buttonNo.gameObject.SetActive(false);
    }

    public void HideDialogueUI()
    {
        gameObject.SetActive(false);
    }

    public void ShouDialogueUI()
    {
        gameObject.SetActive(true);
    }

    public void SetDialogue(string dialogue)
    {
      
        dialogueTxt.text = dialogue;
    }

    public void SetDialogue(char d)
    {
        dialogueTxt.text += d;
    }

    public void ClearText()
    {
        dialogueTxt.text = "";
    }


    public void ShowButton()
    {
        buttonYes.gameObject.SetActive(true);
        buttonNo.gameObject.SetActive(true);
    }

    public void HideButton()
    {
        buttonYes.gameObject.SetActive(false);
        buttonNo.gameObject.SetActive(false);
    }

    public void SetButtonYesText(string buttonName)
    {
        buttonTextYes.text = buttonName;
    }

    public void SetButtonNoText(string buttonName)
    {
        buttonTextNo.text = buttonName;
    }






}
