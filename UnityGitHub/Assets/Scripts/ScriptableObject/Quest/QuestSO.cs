using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "QuestLines/Quest")]
[Serializable]
public class QuestSO : ScriptableObject
{
    public List<StepSO> steps;
    public bool isDone;
}
