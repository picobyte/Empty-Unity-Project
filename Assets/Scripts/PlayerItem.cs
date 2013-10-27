using UnityEngine;
using System.Collections;

public class PlayerItem : MonoBehaviour
{
	private static Item currentItem;
    public static ItemType type
    {
        get
        {
            return currentItem ? currentItem.type : ItemType.None;
        }
    }

	public void OnReceiveItem(Item item)
	{
		if(currentItem)
		{
			Debug.Log("Returning current item.");
			currentItem.transform.parent = null;
            currentItem.Return();
            Activatable.OnEventForAll(currentItem.type, false);
		}
		currentItem = item;
        if(item)
        {
			Debug.Log("Setting new item");
            GetComponent<PlayerMovement>().respawnPoint = currentItem.transform.position + Vector3.up;
            
            currentItem.transform.parent = transform;
            currentItem.transform.localPosition = Vector3.zero;
            
            Activatable.OnEventForAll(item.type, true);
        }
	}
}
