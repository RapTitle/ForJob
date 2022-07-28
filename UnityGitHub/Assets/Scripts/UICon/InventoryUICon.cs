using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InventoryUICon : MonoBehaviour
{
    //对子物体的引用
    [Header("子物体引用")]
    [SerializeField] private TabGroupCon tabGroup;
    [SerializeField] private ItemDetailedUICon itemDetailed; 
    [SerializeField] private ItemUseCon itemShowUse;
    [SerializeField] private List<ItemGridCon> itemGrids;
   
    
    //数据存储
    [Header("玩家背包仓库")] 
    [SerializeField] private InventorySO playerInventory;

    [Header("背包标签分页")] 
    [SerializeField] private List<TabTypeSO> tabTypes;


    [Header("广播事件")] 
    [SerializeField] private ItemEventChannelSO useItemEvent;

    [SerializeField] private ItemEventChannelSO equipItemEvent;

    [SerializeField] private ItemEventChannelSO otherItemEvent;

    [SerializeField] private IntEventChannelSO restoreHealth;

    //当前分页
    ////装填前要知道当前分页情况，所以需要一个TabTypeSO存储
    private TabTypeSO selectTab;
    private ItemGridCon selectGrid; 
    private List<RaycastResult> list = new List<RaycastResult>();


  private UnityAction onCancelSelect;
  //监听每一个Grid,当选中时将详细信息送到此面板
  private void Awake()
  {
      for (int i = 0; i < itemGrids.Count; i++)
      {
          itemGrids[i].onSelectItem += itemDetailed.ShowDetails;
         // onCancelSelect += itemGrids[i].CancelSelect;
      }
  }


  private void OnEnable()
    {
        //Tab初始化
        //Tab页面初始化,并且onChangeTab应该绑定一个方法，当onChangeTab执行时，切换分页
        tabGroup.SetTabGroup(tabTypes);
        tabGroup.onChangeTab+=ChangeTab;
        selectTab = tabTypes[0];
        itemShowUse.onClicked += UseItem;
        //
        FillInventory();
        
        
        
        //开始分页应该置于第一个分页
        //没有选中任何物品所以itemDetailed界面不显示
        
        //启动对鼠标的监听
         StartCoroutine(nameof(ListenMouse));
    }


  public void HideInventoryUI()
  {
      gameObject.SetActive(false);
  }

  public void ShowInventoryUI()
  {
      gameObject.SetActive(true);
  }

  private void OnDisable()
  {
      itemShowUse.onClicked = null;
     // itemShowUse.onClicked -= UseItem;
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
               itemGrids[i].SetData(listitemStack[i]);
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
        if(onCancelSelect!=null)
            onCancelSelect();
    }
    
    
    //选中ItemGrid
    //打开背包面板是启动协程监听鼠标

    IEnumerator ListenMouse()
    {
        while (gameObject.activeSelf)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (ClickItem()!=null&&ClickItem().tag == "Grid")
                {
                    if (ClickItem().TryGetComponent<ItemGridCon>(out selectGrid))
                    {
                        if(onCancelSelect!=null) 
                            onCancelSelect();
                       
                        onCancelSelect = null;
                        selectGrid.SelectItem();
                        itemShowUse.SetButton(selectGrid.currItemStack);
                        onCancelSelect += selectGrid.CancelSelect;
                    }
                }
                else
                {
                   
                }
            }
                 yield return null;
        }

       
    }
    
    //来自知乎的代码https://zhuanlan.zhihu.com/p/144098931
 
  
    private GameObject ClickItem()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);

        eventData.position = Input.mousePosition;
        
        EventSystem.current.RaycastAll(eventData,list);
        var raycast = FindFirstRaycast(list);

        // var go = ExecuteEvents.GetEventHandler<IEventSystemHandler>(raycast.gameObject);
        // if (go == null)
        //     go = raycast.gameObject;
        // Debug.Log(go.gameObject.name);

        GameObject go = raycast.gameObject;
        return go;
    }

    private RaycastResult FindFirstRaycast(List<RaycastResult> candidates)
    {
        for (var i = 0; i < candidates.Count; i++)
        {
            if(candidates[i].gameObject==null)
                continue;
            ;
            return candidates[i];
        }

        return new RaycastResult();
    }

    private void UseItem()
    {
      
        if (selectGrid.currItemStack != null)
        {
            ItemSO itemToAction = ScriptableObject.CreateInstance<ItemSO>();
            itemToAction = selectGrid.currItemStack.item;
            switch (itemToAction.itemType.actionType)
            {
                case ActionType.Equip:
                    equipItemEvent.OnRaisedEvent(itemToAction);
                    FillInventory();
                    Debug.Log("装备");
                    break;
                case ActionType.Use:
                    useItemEvent.OnRaisedEvent(itemToAction);
                    FillInventory();
                    Debug.Log("使用物品");
                    break;
                case ActionType.DoNothing:
                    otherItemEvent.OnRaisedEvent(itemToAction);
                    //FillInventory();
                    Debug.Log("扩展道具");
                    break;
                    
            }
        }
    }
}
