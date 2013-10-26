using UnityEngine;
using System.Collections;

public class PlatformMover : Activatable {

    public float blockspeed = 7;
    public float waitTime = 2;
    public Vector3 endPos;

	public bool isMoving { private get; set; }
	
	// Use this for initialization
	void Awake () 
	{
		isMoving = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(isActive && isMoving)
        {
        transform.position = Vector3.MoveTowards(transform.position, endPos, Time.deltaTime*blockspeed);
        }
	}
    
    protected override void OnStatusChange(bool active)
    {
    
    }
}
