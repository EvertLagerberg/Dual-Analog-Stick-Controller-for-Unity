using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class MoveScript : MonoBehaviour {


	GameObject cam;

	public float jumpSpeed = 2000.0F;
	public float gravity = 2000.0F;


	public float runspeed = 0.03F;
	private float runstep;
	
	public float lookVerticalspeed = 0.2F;
	private float lookVerticalstep;


	public float lookHorizontalspeed = 0.2F;
	private float lookHorizontalstep;

	private Vector3 moveDirection = Vector3.zero;
	//LeftStick Position Variables
	Vector2 LStick = Vector2.zero;
	public int LbuttonState = 1;
	
	//RightStick Position Variables
	Vector2 RStick = Vector2.zero;
	public int RbuttonState = 1;


	SerialPort Serial = new SerialPort("/dev/tty.usbmodem1421", 9600);



	// Use this for initialization
	void Start () 
	{
		Serial.Open();
		Serial.ReadTimeout = 5;
		cam = GameObject.Find ("First Person Controller/Main Camera");
		
	}
	
	// Update is called once per frame
	void Update () {
		
		runstep = runspeed * Time.deltaTime;
		lookVerticalstep = lookVerticalspeed * Time.deltaTime;
		lookHorizontalstep = lookHorizontalspeed * Time.deltaTime;
		
		if (Serial.IsOpen) 
		{
			
			try
			{
				if (Serial.ReadLine() != null){
					
					MoveObject(Serial.ReadLine());
					//print(Serial.ReadLine());
					
				}
			}
			catch(System.Exception)
			{
				print("Exception");
				
			}
			
			
			
		}
		
	}
	
	
	void MoveObject(string Input) 
	{


	
		//Split xPosition, yPosition and Buttonstate
		string[] data = Input.Split(',');
		
		
		//Check that exactly those three where given
		if(data.Length == 6)
		{



			//LeftStick
			LStick= deadZone(int.Parse(data[0]), int.Parse(data[1]), LStick);
		
			//LeftStick Check that the buttonState is 0 or 1
			
			int tempButton = int.Parse(data[2]);
			if (tempButton == 0 || tempButton == 1) 
			{
				LbuttonState= tempButton;		
			}
			


			//RightStick
			RStick = deadZone(int.Parse(data[3]), int.Parse(data[4]),RStick);
		

			//RightStick Check that the buttonState is 0 or 1
			tempButton = int.Parse(data[5]);
			if (tempButton == 0 || tempButton == 1) 
			{

				RbuttonState= tempButton;		
			}
			
		}



		//Set character movment direction
		CharacterController controller = GetComponent<CharacterController> ();
		if (controller.isGrounded) 
		{
			moveDirection = new Vector3(LStick.x,0,LStick.y);
			moveDirection = transform.TransformDirection(moveDirection);

			if (RbuttonState == 0)
			{
				moveDirection.y = jumpSpeed;
			
			}
		
		
		}

		//Move the character
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * runstep);


		//Rotate Character Camera
		transform.Rotate (new Vector3 (0, RStick.x, 0)*lookHorizontalstep, Space.World);
		cam.transform.Rotate(new Vector3 (-1*RStick.y, 0, 0) *lookVerticalstep);
		
	}


	//Function that returns zero if thumbstick position is within deadZone.
	Vector2 deadZone(int x, int y, Vector2 lastInput)
	{
		if (Mathf.Abs (x) < 600 && Mathf.Abs (y) < 600) 
		{

			float deadzone = 30.0f;
			
			Vector2 v= new Vector2(x, y);

			if(v.magnitude < deadzone)
			{                      
				//DEADZONE
				v = Vector2.zero;
			}
			return v;
		
		}
		return lastInput;

	}



}
