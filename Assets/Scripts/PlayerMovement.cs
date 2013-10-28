using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public bool canControl = true;

    private CharacterController controller;
    private Vector3 _movement;
    public Vector3 movement{ get{ return _movement; } }
    public Vector3 input{ private set; get; }
	
	public Vector3 respawnPoint = Vector3.zero;
    
    public float speed = 10;
    public float gravity = 10;
    public float jumpPower = 10;
    public float airSpeed = 5;
	public float minAirSpeed = 3;
    
    private float maxAirSpeed;

	void Awake()
    {
        controller = GetComponent<CharacterController>();
	}
	
	void Update()
    {
        if(canControl)
        {
            input = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        }
        else
        {
            input = Vector3.zero;
        }
        
        if(controller.isGrounded)
        {
            _movement = input * speed;
            if(canControl && Input.GetButtonDown("Jump"))
            {
                _movement.y = jumpPower;
                maxAirSpeed = Mathf.Max(minAirSpeed, Mathf.Abs(_movement.x));
            }
            else
            {
                _movement.y = -3;
                maxAirSpeed = speed;
            }
        }
        else
        {
            _movement += input * airSpeed * Time.deltaTime;
            _movement.x = Mathf.Clamp(_movement.x, -maxAirSpeed, maxAirSpeed);
            _movement.y -= gravity * Time.deltaTime;
        }
        
        var previousPosition = transform.position;
        controller.Move(_movement * Time.deltaTime);
        
        _movement = (transform.position - previousPosition) / Time.deltaTime;
	}
}
