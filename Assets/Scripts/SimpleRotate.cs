using UnityEngine;
using System.Collections;

public class SimpleRotate : MonoBehaviour
{
	public Vector3 rotation;
	
    void Start()
    {
        transform.Rotate(rotation * Random.value * 360);
    }
    
	void Update()
    {
        transform.Rotate(rotation * 10 * Time.deltaTime);
	}
}
