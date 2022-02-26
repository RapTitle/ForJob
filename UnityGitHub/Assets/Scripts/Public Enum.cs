using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActionType
{
    DoNothing,
    Use,
    Equip,
}

public enum TabType
{
    Item,
    Equip,
    Tresure,
}

public enum ItemType
{
    Food,
    Clothes,
    Weapons,
    Tresure,
    
    
}

public enum StepType
{
    None,
    Dialogue,
    Accept,
    Give,
    Check,
}

[Serializable]
public class ChoiceButton
{
    public string choiceName;
    public DialogueLineSO myDialogueData;
}