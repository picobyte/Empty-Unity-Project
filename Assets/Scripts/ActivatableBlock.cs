using UnityEngine;
using System.Collections;

public abstract class ActivatableBlock : Activatable
{
	private Material originalMaterial;
    [SerializeField]
    private Material inactiveMaterial;

	override protected void Awake()
	{
		base.Awake();
		originalMaterial = renderer.sharedMaterial;
		renderer.sharedMaterial = inactiveMaterial;
	}
	
	override protected void OnEvent(bool activate)
	{
		renderer.sharedMaterial = activate ? originalMaterial : inactiveMaterial;
		base.OnEvent(activate);
	}
}
