using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySO playerInventory;
    [SerializeField] private GameObject g;

    [Header("监听事件")] 
    [SerializeField] private ItemEventChannelSO useItemEvent;

    [SerializeField] private ItemEventChannelSO equipItemEvent;

    [SerializeField] private ItemEventChannelSO otherItemEvent;


    private void OnEnable()
    {
         // StartCoroutine(SaveSystem.GetInstance().LoadSaveInventory());
    }
    
    

}
