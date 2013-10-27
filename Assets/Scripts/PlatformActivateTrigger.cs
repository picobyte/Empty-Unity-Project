using UnityEngine;
using System.Collections;

public class PlatformActivateTrigger : MonoBehaviour
{
	public GameObject target;
	public bool holdPlayer = true;
	
	void OnTriggerEnter(Collider other)
	{
		var mover = target.GetComponent<PlatformMover>();
		if(mover && mover.isActive && !mover.playerOnIt)
		{
			Debug.Log("Ghost entered lift platform.");
			mover.playerOnIt = true;
			if(holdPlayer) {
					var player =
						other.gameObject.GetComponent<PlayerMovement>();
					if(player) {
						other.transform.parent = target.transform;
					}
			}
		}
	}
        
	void OnTriggerExit(Collider other)
	{
		Debug.Log("Ghost left lift platform.");
		var mover = target.GetComponent<PlatformMover>();
		if(holdPlayer) {
			if(mover) {
				mover.playerOnIt = false;
			}
			var player = other.gameObject.GetComponent<PlayerMovement>();
			if(player) {
				other.transform.parent = null;
			}
		}
	}
}
