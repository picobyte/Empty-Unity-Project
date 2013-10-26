using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour
{
	void OnTriggerEnter(Collider other) 
	{
		var pitem = other.GetComponent<PlayerItem>();
		if(pitem) {
			pitem.OnReceiveItem(null);
		}
		var movement = other.GetComponent<PlayerMovement>();
		if(movement) {
			other.transform.position = movement.respawnPoint;
		}
	}
}
