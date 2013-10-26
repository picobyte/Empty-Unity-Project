using UnityEngine;
using System.Collections;

public class PassablePlatform : Activatable
{
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
		collider.isTrigger = active;
    }
}
