using UnityEngine;
using System.Collections;

public class ActivatableText : Activatable 
{
	protected override void Awake()
	{
		base.Awake();
		renderer.enabled = false;
	}

	protected override void OnStatusChange(bool active)
    {
		renderer.enabled = active;
    }
}
