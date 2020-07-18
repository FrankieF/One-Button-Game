using UnityEngine;
using System.Collections;

public class Fish : MonoBehaviour
{
	// Move speed for fish
	public float moveSpeed = 5f;
	
	public bool Right;
	public bool Left;

	public Rigidbody rigidbody;
	
	
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody> ();
    }
	
	void Start ()
	{
				
	}
	
	void Update ()
	{
		FishMovement();
	}	
	
	// Makes sharks start by going left or right depending on bool
	protected void FishMovement()
	{
		if (Right)
		{
			rigidbody.velocity = Vector3.right * moveSpeed;	
		}
		
		if (Left)
		{
			rigidbody.velocity = Vector3.left * moveSpeed;
		}
	}
	
	// If the fish hit walls they will reverse direction
	void OnCollisionEnter(Collision Other)
	{
		if (Other.collider.name == "Walls")
		{
			//body.velocity = body.velocity.normalized * moveSpeed * -1f;
			if (Right)
			{
				Right=false;
				Left=true;
				moveSpeed=5f;
			}
			else
			{
				Left=false;
				Right=true;
				moveSpeed=5f;
			}
		}
	}
}
