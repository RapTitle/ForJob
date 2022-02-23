using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TabUICon : MonoBehaviour
{
   
   //引用对象
   private Button b;
   [SerializeField] private GameObject buttonF;
   
   //存储数据
   private TabTypeSO currTabType;


   public UnityAction<TabTypeSO> onSelectTab;

   private void Awake()
   {
      b = GetComponent<Button>();
   }

   //初始化
   public void SetTab(TabTypeSO tabType)
   {
      currTabType = tabType;
      b.onClick.AddListener(OnSelectTab);
   }

   //
   private void OnSelectTab()
   {
      onSelectTab.Invoke(currTabType);
     // buttonF.SetActive(true);
   }
}
