using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Renderer))]
public class UVAnimation : MonoBehaviour
{
	public Vector2 speed;
    
    private Material mat;
    private Vector2 pos;
    
    
    void Awake()
    {
        mat = renderer.material;
        pos = mat.mainTextureOffset;
    }
    
	void Update()
    {
        pos += speed * Time.deltaTime;
        
        pos.x = Mathf.Repeat(pos.x, 1);
        pos.y = Mathf.Repeat(pos.y, 1);
    
        mat.mainTextureOffset = pos;
	}
}
