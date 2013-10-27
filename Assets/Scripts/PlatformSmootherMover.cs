using UnityEngine;
using System.Collections;

public class PlatformSmootherMover : ActivatableBlock
{

    //public float blockspeed = 7;
    //public float waitTime = 2;
    public Vector3 endPos;
    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;


	public bool isMoving { private get; set; }
	
	// Use this for initialization
	void Awake () 
	{
		isMoving = false;
	}
	
	// Update is called once per frame
	void Update () {
        //var step = Time.deltaTime*blockspeed;
        if(isActive && isMoving)
        {
        transform.position = Vector3.SmoothDamp(transform.position, endPos, ref velocity, smoothTime);
        }
	}
    
    protected override void OnStatusChange(bool active)
    {
    
    }
}
