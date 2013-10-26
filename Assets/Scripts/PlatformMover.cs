using UnityEngine;
using System.Collections;

public class PlatformMover : Activatable {

    public float blockspeed = 7;
    public float waitTime = 2;
    public Vector3 endPos;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(isActive)
        {
        transform.position = Vector3.Lerp(transform.position, endPos, Time.deltaTime*blockspeed);
        }
	}
    
    protected override void OnStatusChange(bool active)
    {
    
    }
}
