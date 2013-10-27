using UnityEngine;
using System.Collections;

public class PlatformActivateTrigger : MonoBehaviour 
{
	public GameObject target;
	public bool holdPlayer = true;
    
    private Transform player;
	
	void OnTriggerEnter(Collider other) 
	{
        if(!other.CompareTag("Player")) return;
    
        StopAllCoroutines();
    
		var mover = target.GetComponent<PlatformMover>();
		if(mover && mover.isActive)
		{
Debug.Log("Ghost entered lift platform.");
			mover.playerOnIt = true;
			if(holdPlayer)
            {
				player = other.transform;
			}
		}
	}
	
	void OnTriggerExit(Collider other) 
	{
        if(!other.CompareTag("Player")) return;
    
Debug.Log("Ghost left lift platform.");
		var mover = target.GetComponent<PlatformMover>();
		if(holdPlayer)
        {
			if(mover)
            {
                StartCoroutine(DetachPlayer());
			}
		}
	}
    
    IEnumerator DetachPlayer()
    {
print("start detaching");
        yield return new WaitForFixedUpdate();
        yield return new WaitForFixedUpdate();
        if(player)
        {
print("detaching");
            var mover = target.GetComponent<PlatformMover>();
            mover.playerOnIt = false;
            player = null;
        }
    }
    
    private Vector3 previousPosition;
    void LateUpdate()
    {
if(player) print("lateupdate");
        if(player) player.Translate(transform.position - previousPosition, Space.World);
        
        previousPosition = transform.position;
    }
}
