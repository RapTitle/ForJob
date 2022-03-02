using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/ItemEvent")]
public class ItemEventChannelSO : ScriptableObject
{
    public UnityAction<ItemSO> onEventRaised;

    public void OnRaisedEvent(ItemSO item)
    {
        if(onEventRaised!=null)
            onEventRaised.Invoke(item);
    }



}
