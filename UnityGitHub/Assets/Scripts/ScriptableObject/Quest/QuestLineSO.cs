using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "QuestLines/QuestLine")]
[Serializable]
public class QuestLineSO : ScriptableObject
{
    public List<QuestSO> questLines;

    public bool isDone;


}
