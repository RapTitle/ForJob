using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(menuName = "Events/IntEvent")]
public class IntEventChannelSO : ScriptableObject
{
    public UnityAction<int> onEventRaised;

    public void OnRaiseEvent(int value)
    {
        if (onEventRaised != null)
            onEventRaised.Invoke(value);
    }
}
