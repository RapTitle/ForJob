using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="QuestLines/Quests/Steps/DialogueData")]
public class DialogueDataSO : ScriptableObject
{
    public DialogueDataSO(DialogueLineSO dialogueLine, ChoiceDataSO choice)
    {
        this.dialogueLine = dialogueLine;
        this.choiceButton = choice;
    }
    public DialogueLineSO dialogueLine;
    public ChoiceDataSO choiceButton;
}
