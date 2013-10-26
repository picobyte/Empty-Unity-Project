﻿using UnityEngine;
using System.Collections.Generic;

public abstract class Activatable : MonoBehaviour
{
    private static Dictionary<ItemType, HashSet<Activatable>> listeners = new Dictionary<ItemType, HashSet<Activatable>>();

	[SerializeField]
    private ItemType neededItemType;
    private Color originalColor;
    
    void Awake()
    {
        if(!listeners.ContainsKey(neededItemType))
        {
            listeners[neededItemType] = new HashSet<Activatable>();
        }
        listeners[neededItemType].Add(this);
        
        originalColor = renderer.material.color;
        renderer.material.color = Color.black;
    }
    
    void OnDestroy()
    {
        listeners[neededItemType].Remove(this);
    }
    
    public static void OnEventForAll(ItemType type, bool activate)
    {
        if(!listeners.ContainsKey(type)) return;
        foreach(var a in listeners[type])
        {
            a.OnEvent(activate);
        }
    }
    
    private void OnEvent(bool activate)
    {
        renderer.material.color = activate ? originalColor : Color.black;
        OnStatusChange(activate);
    }
    
    protected virtual void OnStatusChange(bool active)
    {
    
    }
    
    protected bool isActive
    {
        get{ return neededItemType == PlayerItem.type; }
    }
}