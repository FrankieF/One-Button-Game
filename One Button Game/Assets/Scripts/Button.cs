using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour
{
	// duration of required to input "hold"
	public float holdtime;
	
	float timer = 0f;
	
	void Start ()
	{
		
	}
	
	
	void Update ()
	{
		// for button down
		//Input.GetButtonDown ("ButtonName");
		
		// for holding button
		//Input.GetButton("ButtonName");
		
		// for button coming up
		//Input.GetButtonUp("ButtonName");
		
		// count up when button is held
		if (Input.GetKey(KeyCode.Space))
		{
			timer += Time.deltaTime;
		}
		
		if (Input.GetKeyUp(KeyCode.Space))
		{
			if (timer >= holdtime)
			{
				Debug.Log("Hold");
			}
			else 
			{
				Debug.Log ("Tap");
			}
			timer = 0f;
		}
		
	}
}
