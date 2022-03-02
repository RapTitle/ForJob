using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCon : MonoBehaviour
{
    [SerializeField] private ItemSO item;

    public ItemSO ReturnItem()
    {
        return item;
    }
}
