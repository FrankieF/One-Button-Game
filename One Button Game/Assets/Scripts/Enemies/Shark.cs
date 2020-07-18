using UnityEngine;
using System.Collections;

public class Shark : MonoBehaviour
{
	// Move speed determines how fast the sharks move
	public float moveSpeed = 3f;
		public Rigidbody rigidbody;
	
	// Sets Left to true to start 2 sharks moving in Left direction
	public bool Left = true;
	
	// Bool for making shark move Right, to have 1 shark move right
	public bool Right = false;
	
	void Awake()
	{
		rigidbody = GetComponent<Rigidbody> ();
	}

	void Start ()
	{
				
	}
	
	void Update ()
	{
        EnemyMovement();
    }	
	
	// Makes sharks start by going left or right depending on bool
	protected void EnemyMovement()
	{
		rigidbody.velocity = Vector3.right * moveSpeed;	
	}
	
	// If a Shark hits a wall it reverses direction
	void OnCollisionEnter(Collision Other)
	{
		if (Other.collider.name == "Walls")
		{
            moveSpeed *= -1;
		}
	}
}
