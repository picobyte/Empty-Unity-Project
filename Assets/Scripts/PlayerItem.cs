using UnityEngine;
using System.Collections;

public class PlayerItem : MonoBehaviour
{
	private GameObject currentItem;

	void OnRecieveItem(GameObject item)
	{
		if(currentItem)
		{
			Destroy(currentItem);
		}
		currentItem = item;
		currentItem.transform.parent = transform;
		currentItem.transform.localPosition = new Vector3(0,0,0);
	}
}
