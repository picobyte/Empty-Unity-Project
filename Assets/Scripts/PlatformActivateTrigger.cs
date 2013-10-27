using UnityEngine;
using System.Collections;

public class PlatformActivateTrigger : MonoBehaviour 
{
	public GameObject target;
	public bool holdPlayer = true;
	
	void OnTriggerEnter(Collider other) 
	{
		var mover = target.GetComponent<PlatformMover>();
		if(mover && mover.isActive)
		{
			Debug.Log("Ghost entered lift platform.");
			mover.isMoving = true;
			if(holdPlayer) {
				other.transform.parent = target.transform;
			}
		}
	}
	
	void OnTriggerExit(Collider other) 
	{
		Debug.Log("Ghost left lift platform.");
		var mover = target.GetComponent<PlatformMover>();
		if(holdPlayer) {
			if(mover) {
				mover.isMoving = false;
			}
			other.transform.parent = null;
		}
	}
}
