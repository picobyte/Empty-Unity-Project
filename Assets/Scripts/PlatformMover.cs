using UnityEngine;
using System.Collections;

public class PlatformMover : Activatable {

    public float blockspeed = 7;
    public float waitTime = 2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(isActive)
        {
        
        }
	}
    
    protected override void OnStatusChange(bool active)
    {
    
    }
}
