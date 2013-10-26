using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 movement;
    
    public float speed = 10;
    public float gravity = 10;
    public float jumpPower = 10;
    

	void Awake()
    {
        controller = GetComponent<CharacterController>();
	}
	
	void Update()
    {
        var input = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        
        if(controller.isGrounded)
        {
            movement = input * speed;
            if(Input.GetButtonDown("Jump"))
            {
                movement.y = jumpPower;
            }
            else
            {
                movement.y = -1;
            }
        }
        else
        {
            movement.y -= gravity * Time.deltaTime;
        }
        
        controller.Move(movement * Time.deltaTime);
	}
}
