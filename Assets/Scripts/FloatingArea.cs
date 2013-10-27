using UnityEngine;
using System.Collections;

public class FloatingArea : Activatable 
{

	public GameObject particleSystem;
	private float previousGravity;

	void OnTriggerEnter(Collider other)
	{
        if(isActive)
        {
			var movement = other.GetComponent<PlayerMovement>();
			if(!movement) {
				return;
			}
			previousGravity = movement.gravity;
			movement.gravity = -5;
        }
	}

	void OnTriggerExit(Collider other)
	{
		if(isActive) {
			var movement = other.GetComponent<PlayerMovement>();
			if(!movement) {
					return;
			}
			movement.gravity = previousGravity;
		}
	}

    protected override void OnStatusChange(bool active)
    {
		var ps = particleSystem.GetComponent<ParticleSystem>();
		if(ps) {
			if(active) {
				ps.Play();
			} else {
				ps.Stop();
			}
		}
    }
}
