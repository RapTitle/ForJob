using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="QuestLines/Quests/Steps/DialogueData")]
public class DialogueDataSO : ScriptableObject
{
    public DialogueLineSO dialogueLine;
    public ChoiceDataSO choiceButton;
}
