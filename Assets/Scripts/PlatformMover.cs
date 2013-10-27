using UnityEngine;
using System.Collections;

public class PlatformMover : ActivatableBlock
{
    [SerializeField]
    private new Renderer renderer;
    
    public float blockspeed = 7;
    public float waitTime = 2;
    public Vector3 endPos;
    private Vector3 startPos;

	public bool playerOnIt;
	
	void Awake() 
	{
		base.Awake();
        startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 targetPos = isActive && playerOnIt ? endPos : startPos;

        transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime*blockspeed);
	}
    
    void OnDrawGizmos()
    {
        Color c = Color.red;
        Gizmos.color = c;
        
        Gizmos.DrawLine(transform.position, endPos);
        
        c.a = 0.3f;
        Gizmos.color = c;
        
        Gizmos.DrawCube(endPos, GetComponentInChildren<Renderer>().transform.localScale);
    }
    
    protected override Renderer getRenderer()
    {
        return renderer;
    }
}
