using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TabGroupCon : MonoBehaviour
{
    //对子物体的引用
    [SerializeField] private List<TabUICon> tabButtonList;


    public UnityAction<TabTypeSO> onChangeTab;

    public void SetTabGroup(List<TabTypeSO> tabTypeList)
    {
        if (tabButtonList == null)
        {
            tabButtonList = new List<TabUICon>();
        }

        int min = Mathf.Min(tabButtonList.Count, tabTypeList.Count);
        for (int i = 0; i < min; i++)
        {
            tabButtonList[i].SetTab(tabTypeList[i]);
            tabButtonList[i].onSelectTab += OnChangeTab;
        }
    }

    private void OnChangeTab(TabTypeSO tabType)
    {
        if(tabType!=null)
            onChangeTab.Invoke(tabType);
    }

}
