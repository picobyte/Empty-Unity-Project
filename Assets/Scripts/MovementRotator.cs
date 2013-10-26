using UnityEngine;
using System.Collections;

public class MovementRotator : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement pm;

	void LateUpdate()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(-Vector3.forward + pm.input), 20 * Time.deltaTime);
	}
}
