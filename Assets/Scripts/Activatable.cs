using UnityEngine;
using System.Collections.Generic;

public abstract class Activatable : MonoBehaviour
{
    private static Dictionary<ItemType, HashSet<Activatable>> listeners = new Dictionary<ItemType, HashSet<Activatable>>();

	[SerializeField]
    private ItemType neededItemType;
    
    protected virtual void Awake()
    {
        if(!listeners.ContainsKey(neededItemType))
        {
            listeners[neededItemType] = new HashSet<Activatable>();
        }
        listeners[neededItemType].Add(this);
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
    
    protected virtual void OnEvent(bool activate)
    {
		OnStatusChange(activate);
    }
    
    protected virtual void OnStatusChange(bool active)
    {
	
    }
    
    public bool isActive
    {
        get{ return neededItemType == PlayerItem.type; }
    }
}
