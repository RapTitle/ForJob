using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //整合Ui的服务，算作一个接口，真正的工作交给底层的text
    
    //如果不使用单例模式，就应该使用ScriptableObject
    //为了简单还是使用单例模式吧

    [SerializeField] private DialogueUICon dialogueUICon;

    public DialogueData dialogueData;
    


    public void SetDialogue(DialogueData data)
    {
        dialogueUICon.ShowDialogue(dialogueData);
      
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
            SetDialogue(dialogueData);
    }
}
