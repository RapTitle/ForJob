using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T>  : MonoBehaviour where T:Component
{
    private static T instance;

    public static T GetInstance()
    {
        return instance;
    }

    protected virtual void Awake()
    {
        instance = this as T;
    }
}
