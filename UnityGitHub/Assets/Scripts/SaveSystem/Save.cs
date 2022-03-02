using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Save
{
   public int saveQueseLine;
   public int saveQuest;
   public int saveStep;

   public List<SerializedItemStack> itemStacks = new List<SerializedItemStack>();

   public string ToJsonm()
   {
      return JsonUtility.ToJson(this);
   }

   public void LoadFromJson(string json)
   {
      JsonUtility.FromJsonOverwrite(json,this);
   }
}
