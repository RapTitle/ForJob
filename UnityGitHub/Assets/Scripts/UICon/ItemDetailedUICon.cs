using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDetailedUICon : MonoBehaviour
{
    [SerializeField] private Text itemText;


    //当选中一项物品后，应该将此物品的详细描述返回给此页面。
    public void ShowDetails(ItemStack itemStack)
    {
        if (itemStack == null)
        {
            Debug.Log("空格子");
            HideDetails();
            return;
        }
        gameObject.SetActive(true);
        itemText.text = itemStack.item.itemDescribe;
        
    }

    public void HideDetails()
    {
        gameObject.SetActive(false);
    }
}
