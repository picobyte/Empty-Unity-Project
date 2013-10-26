using UnityEngine;
using System.Collections;

public class MovementBender : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement pm;
    public Vector3 target;
    private Quaternion startRotation;
    
    
    void Awake()
    {
        startRotation = transform.localRotation;
    }
	
	void LateUpdate()
    {
        var targetRotation = Quaternion.Slerp(startRotation, Quaternion.Euler(target), Mathf.Abs(pm.input.x));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, Time.deltaTime * 20);
	}
}
