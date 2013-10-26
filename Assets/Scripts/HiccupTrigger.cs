using UnityEngine;
using System.Collections;

public class HiccupTrigger : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
	{
		var controller = other.GetComponent<CharacterController>();
		controller.Move(new Vector3(0,50,0) * Time.deltaTime);
	}
}
