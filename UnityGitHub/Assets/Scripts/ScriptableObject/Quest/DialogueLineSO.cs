using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DialogueLine")]
[Serializable]
public class DialogueLineSO : ScriptableObject
{
   [TextArea]
   public List<string> dialogues;
}
