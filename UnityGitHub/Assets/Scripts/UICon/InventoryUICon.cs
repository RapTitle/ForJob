using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUICon : MonoBehaviour
{
    //对子物体的引用
    [Header("子物体引用")]
    [SerializeField] private TabGroupCon tabGroup;
    [SerializeField] private ItemDetailedUICon itemDetailed;
    [SerializeField] private List<ItemGridCon> itemGrids;
    
    //数据存储
    [Header("玩家背包仓库")] 
    [SerializeField] private InventorySO playerInventory;

    [Header("背包标签分页")] 
    [SerializeField] private List<TabTypeSO> tabTypes;
    
    //当前分页
    ////装填前要知道当前分页情况，所以需要一个TabTypeSO存储
  [SerializeField]  private TabTypeSO selectTab;


    private void OnEnable()
    {
        //Tab初始化
        //Tab页面初始化,并且onChangeTab应该绑定一个方法，当onChangeTab执行时，切换分页
        tabGroup.SetTabGroup(tabTypes);
        tabGroup.onChangeTab+=ChangeTab;
        selectTab = tabTypes[0];
        
        //
        FillInventory();
        
        
        //开始分页应该置于第一个分页
        //没有选中任何物品所以itemDetailed界面不显示
    }


    private void FillInventory()
    {
        List<ItemStack> listItemStack = new List<ItemStack>();
        for (int i = 0; i < playerInventory.currItemStacks.Count; i++)
        {
            if (playerInventory.currItemStacks[i].item.itemType.tabTypeSO == selectTab)
            {
                listItemStack.Add(playerInventory.currItemStacks[i]);
            }
        }
        FillInventoryItem(listItemStack);
    }


    private void FillInventoryItem(List<ItemStack> listitemStack)
    {
        if (itemGrids == null)
        {
            itemGrids = new List<ItemGridCon>();
            Debug.Log("Error");
        }
        if(listitemStack.Count>itemGrids.Count)
            Debug.Log("超出背包大小");
        for (int i = 0; i < itemGrids.Count; i++)
        {
            if (i < listitemStack.Count)
            {
                //等级颜色设置
                itemGrids[i].SetItemF(listitemStack[i].item.itemColor);
                //数量设置
                itemGrids[i].SetItemAmount(listitemStack[i].amount);
            }
            else
            {
                itemGrids[i].SetItemNull();
            }
        }
    }

    private void ChangeTab(TabTypeSO tabType)
    {
        selectTab = tabType;
        FillInventory();
    }
}
