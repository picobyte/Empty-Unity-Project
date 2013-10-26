using UnityEngine;
using System.Collections;

public class ColorTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other)
	{
		var controller = other.GetComponent<CharacterController>();
		controller.Move(new Vector3(0,50,0) * Time.deltaTime);
	}
}
