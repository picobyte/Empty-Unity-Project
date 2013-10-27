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
		originalMaterial = getRenderer().sharedMaterial;
		getRenderer().sharedMaterial = inactiveMaterial;
	}
	
	override protected void OnEvent(bool activate)
	{
		getRenderer().sharedMaterial = activate ? originalMaterial : inactiveMaterial;
		base.OnEvent(activate);
	}
    
    protected virtual Renderer getRenderer()
    {
        return renderer;
    }
}
