using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DialogueData")]
public class DialogueData : ScriptableObject
{
   [TextArea]
   public List<string> dialogue;
}
