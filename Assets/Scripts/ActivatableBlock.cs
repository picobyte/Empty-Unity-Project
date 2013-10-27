using UnityEngine;
using System.Collections;

public abstract class ActivatableBlock : Activatable
{
	private Color originalColor;

	override protected void Awake()
	{
		base.Awake();
		originalColor = renderer.material.color;
		renderer.material.color = Color.black;
	}
	
	override protected void OnEvent(bool activate)
	{
		renderer.material.color = activate ? originalColor : Color.black;
		base.OnEvent(activate);
	}
}
