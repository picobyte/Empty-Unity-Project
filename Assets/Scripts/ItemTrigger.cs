using UnityEngine;
using System.Collections;

public class ItemTrigger : MonoBehaviour
{
	private Vector3 originalPosition;
	
	void Awake()
	{
		originalPosition = transform.position;
	}

	void OnTriggerEnter(Collider other)
	{
		var item = other.GetComponent<PlayerItem>();
		if(!item) {
			return;
		}
	}
}
