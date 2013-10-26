using UnityEngine;
using System.Collections;

public class SimpleRotate : MonoBehaviour
{
	public Vector3 rotation;
	
	void Update()
    {
        transform.Rotate(rotation * 10 * Time.deltaTime);
	}
}
