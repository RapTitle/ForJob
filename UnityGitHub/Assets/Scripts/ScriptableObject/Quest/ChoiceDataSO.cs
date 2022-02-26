using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "QuestLines/Quests/Steps/DialogueLines/ChoiceData")]
[Serializable]
public class ChoiceDataSO : ScriptableObject
{
    public List<ChoiceButton> choiceButtons;
}


