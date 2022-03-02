using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItemUseCon : MonoBehaviour
{
   private Button itemUseButton;
   [SerializeField] private Text itemUseText;
   

   public UnityAction onClicked;

   private void Awake()
   {
      itemUseButton = GetComponent<Button>();
      itemUseText = itemUseButton.GetComponentInChildren<Text>();
      itemUseButton.onClick.AddListener(OnClicked);
   }

   public void SetButton(ItemStack itemStack)
   {
      if (itemStack != null)
      {
         if (itemStack.item.itemType.actionName =="")
         {
            gameObject.SetActive(false);
              return;
         }
          
         gameObject.SetActive(true);
         itemUseText.text = itemStack.item.itemType.actionName;
      }
   
      else 
         gameObject.SetActive(false);
   }

   private void OnClicked()
   {
      if (onClicked != null)
         onClicked();
   }
}
