using UnityEngine;
using System.Collections;

public class PlatformActivateTrigger : MonoBehaviour 
{
	public GameObject target;
	
	void OnTriggerEnter(Collider other) 
	{
		var mover = target.GetComponent<PlatformMover>();
		mover.isMoving = true;
	}
	
	void OnTriggerExit(Collider other) 
	{
		var mover = target.GetComponent<PlatformMover>();
		mover.isMoving = false;
	}
}
