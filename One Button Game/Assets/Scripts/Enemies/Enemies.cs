using UnityEngine;
using System.Collections;

public class Enemies : MonoBehaviour
{
	// Move speed determines how fast the enemies move
	protected float moveSpeed;
	public Rigidbody body;
	
	//Checks to see if enemy is on axis
	public bool EnemySpawned;
	
	protected bool Right;

    void Awake()
    {
        body = GetComponent<Rigidbody> ();
    }
	
	void Start ()
	{
		
	}
	
	
	void Update ()
	{
        EnemyMovement();
	}
	
	// Movement for enemies
	protected void EnemyMovement()
	{
	    body.velocity = Vector3.right * moveSpeed;	
	}
	
	public void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.name == "Wall")
		{
            moveSpeed *= 1f;
		}
	}
}
