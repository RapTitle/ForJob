using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/ItemType")]
public class ItemTypeSO : ScriptableObject
{
    //显示在按钮上的文字
    public string actionName;
    //物品小类型
    public ItemType itemType;
    //按钮按下后的事件类型
    public ActionType actionType;
    //分页类型
    public TabTypeSO tabTypeSO;
}
