using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Inventory")]

public class InventorySO : ScriptableObject
{
   //使用两个背包，一个是保存，一个即使
   //private List<ItemStack> itemStacks;
   [SerializeField] public List<ItemStack> currItemStacks;


   //背包物品添加
   public void AddItem(ItemSO item, int count = 1)
   {
       for (int i = 0; i < currItemStacks.Count; i++)
       {
           if (item == currItemStacks[i].item)
           {
               currItemStacks[i].amount += count;
               return;
           }
       }
       currItemStacks.Add(new ItemStack(item,count));
   }
   
   //背包物品减少
   public void Remove(ItemSO item, int count = 1)
   {
       if (count <= 0)
           return;
       for (int i = 0; i < currItemStacks.Count; i++)
       {
           if (item == currItemStacks[i].item)
           {
               if (currItemStacks[i].amount > count)
               {
                   currItemStacks[i].amount -= count;
                   return;
               }
               currItemStacks.Remove(currItemStacks[i]);
           }
       }
   }
   
   //判断物品是否存在
   public bool ItemContains(ItemSO item)
   {
       for (int i = 0; i < currItemStacks.Count; i++)
       {
           if (item == currItemStacks[i].item)
               return true;
       }

       return false;
   }

}

//将Item和Amount合并
[Serializable]
public class ItemStack
{
    public ItemSO item;
    public int amount;

    public ItemStack(ItemSO item, int amount)
    {
        this.item = item;
        this.amount = amount;
    }
}
