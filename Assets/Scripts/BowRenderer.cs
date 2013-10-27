using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
[RequireComponent(typeof(LineRenderer))]
public class BowRenderer : MonoBehaviour
{
    private LineRenderer line;
    [SerializeField]
    private Transform target;
    public float y = 1;
    
	void Awake()
    {
        line = GetComponent<LineRenderer>();
	}

	void Update()
    {
        if(!target) return;
    
    #if UNITY_EDITOR
        line = GetComponent<LineRenderer>();
    #endif
    
        var start = transform.position;
        var end = target.position;
        
        var distance = Vector3.Distance(start, end);
        var segments = Mathf.RoundToInt(Mathf.Max(1, (distance*0.2f)+8));
        
        line.SetVertexCount(segments+1);
        
        for(var i = 0; i <= segments; ++i)
        {
            var t = i*1f / segments; //range from 0 to 1
            
            var up = Vector3.up * y * (-Mathf.Pow(t*2-1, 2)+1);
            line.SetPosition(i, Vector3.Lerp(start, end, t) + up);
        }
	}
}
