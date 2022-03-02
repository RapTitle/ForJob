using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Items/Item")]
public class ItemSO : SerializableScripatleObject
{
    //一个物品具有什么属性
    /*1.物品名字
     2.物品图片
     3.物品数量
     4.物品类型（装别/任务物品/食物/药水）
     5.物品使用方法（喝下/吃下/装备）
     6.物品级别（普通/良好/精良/精英。。。）
     
     */
    //参考UOP1项目，可以将类型等属性划分程一个类型
    public string itemName;
    public Sprite itemSprite;
    [TextArea]
    public string itemDescribe;
    public Color itemColor;
    //有关数值上的改动
    public int value;
    public ItemTypeSO itemType;


}

