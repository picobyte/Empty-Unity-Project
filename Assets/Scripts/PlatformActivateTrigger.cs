using UnityEngine;
using System.Collections;

public class PlatformActivateTrigger : MonoBehaviour 
{
	public GameObject target;
	
	void OnTriggerEnter(Collider other) 
	{
		var mover = target.GetComponent<PlatformMover>();
		if(mover && mover.isActive)
		{
			Debug.Log("Ghost entered lift platform.");
			mover.isMoving = true;
			other.transform.parent = target.transform;
		}
	}
	
	void OnTriggerExit(Collider other) 
	{
		Debug.Log("Ghost left lift platform.");
		var mover = target.GetComponent<PlatformMover>();
		if(mover) {
			mover.isMoving = false;
		}
		other.transform.parent = null;
	}
}
