using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItemGridCon : MonoBehaviour
{
    [SerializeField] private Image itemF;
    [SerializeField] private Image itemGrid;
    [SerializeField] private Text itemAmount;
    [SerializeField] private Image itemSelect;

    private ItemStack currItemStack;

    public UnityAction<ItemStack> onSelectItem;

    //设置物品颜色等级
    public void SetItemF(Color c)
    {
       itemF.gameObject.SetActive(true);
       itemF.color = c;
    }
    
    //设置物品图片u
    public void SetItemGrid(Sprite s)
    {
        itemGrid.gameObject.SetActive(true);
        itemGrid.sprite = s;
    }
    
    //设置物品数量
    public void SetItemAmount(int count = 1)
    {
        itemAmount.gameObject.SetActive(true);
        itemAmount.text = count.ToString();
    }
    
    //物品被选中的方法
    public void SelectItem()
    {
        itemSelect.gameObject.SetActive(true);
        if (onSelectItem != null)
            onSelectItem.Invoke(currItemStack);
    }

    public void SetItemNull()
    {
        itemF.gameObject.SetActive(false);
        itemAmount.text = "";
        itemAmount.gameObject.SetActive(false);
    }
    
    
    

}
