using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 movement;
    
    public float speed = 10;
    public float gravity = 10;
    public float jumpPower = 10;
    public float airSpeed = 5;
    
    private float maxAirSpeed;
    

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
                maxAirSpeed = Mathf.Abs(movement.x);
            }
            else
            {
                movement.y = -1;
            }
        }
        else
        {
            movement += input * airSpeed * Time.deltaTime;
            movement.x = Mathf.Clamp(movement.x, -maxAirSpeed, maxAirSpeed);
            movement.y -= gravity * Time.deltaTime;
        }
        
        controller.Move(movement * Time.deltaTime);
	}
}
