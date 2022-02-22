using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUICon : MonoBehaviour
{
    [SerializeField] private Text dialogueTxt;

    public int num;
    // Start is called before the first frame update

    private Coroutine dialogueCoroutine;


    public void HideDialogueUI()
    {
        gameObject.SetActive(false);
    }

    public void ShouDialogueUI()
    {
        gameObject.SetActive(true);
    }


    public void ShowDialogue(DialogueData data, float speed=0.05f)
    {    
        HideDialogue(data);
        dialogueTxt.text = "";
        WaitForSeconds worrdSpeed = new WaitForSeconds(speed);
        if (dialogueCoroutine != null)
        {
            Debug.Log("Coroutine");
            StopCoroutine(dialogueCoroutine);
            dialogueTxt.text = data.dialogue[num];
            num++;
            dialogueCoroutine = null;



        }
        else
            dialogueCoroutine=StartCoroutine(SetDailogueDataCoroutine(data.dialogue[num], worrdSpeed));
        
    }

    private void HideDialogue(DialogueData data)
    {
        if (num >= data.dialogue.Count)
        {
            Debug.Log("Get");
            num = 0;

        }
    }
    



    IEnumerator SetDailogueDataCoroutine(string data, WaitForSeconds wordSpeed)
    {
        foreach (char w in data)
        {
            dialogueTxt.text += w;
            yield return wordSpeed;
        }
       
        dialogueCoroutine = null;
        num++;
        
    }
    
    
}
