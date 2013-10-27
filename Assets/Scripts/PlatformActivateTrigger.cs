using UnityEngine;
using System.Collections;

public class PlatformActivateTrigger : MonoBehaviour 
{
	public GameObject target;
	public bool holdPlayer = true;
    
    private Transform player;
	
	void OnTriggerEnter(Collider other) 
	{
		var mover = target.GetComponent<PlatformMover>();
		if(mover && mover.isActive)
		{
			//Debug.Log("Ghost entered lift platform.");
			mover.playerOnIt = true;
			if(holdPlayer)
            {
				player = other.transform;
			}
		}
	}
	
	void OnTriggerExit(Collider other) 
	{
		Debug.Log("Ghost left lift platform.");
		var mover = target.GetComponent<PlatformMover>();
		if(holdPlayer)
        {
			if(mover)
            {
				mover.playerOnIt = false;
                player = null;
			}
		}
	}
    
    private Vector3 previousPosition;
    void LateUpdate()
    {
        if(player) player.Translate(transform.position - previousPosition, Space.World);
        
        previousPosition = transform.position;
    }
}
