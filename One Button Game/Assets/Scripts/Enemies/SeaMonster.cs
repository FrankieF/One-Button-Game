using UnityEngine;

public class SeaMonster : MonoBehaviour
{	
	//Move speed for Sea monster
	public float moveSpeed = 5;
	public Rigidbody myrigidbody;
	
	// Determines if Sea Monster turns
	private bool HasNotChanged = false;
	
    void Awake()
    {
        myrigidbody = GetComponent<Rigidbody> ();
    }

	void Start ()
	{
	
	}
	
	
	void Update ()
	{
        EnemyMovement();
    }
	
	// Sets the Sea Monster to Move to the right
	void EnemyMovement()
	{	
		myrigidbody.velocity = Vector3.right * moveSpeed;	
		
	}
	
	// If the Sea Monster hits a wall it reverses direction
	void OnCollisionEnter(Collision Other)
	{
		if (Other.collider.name == "Walls") 
		{
            moveSpeed *= -1;
		}
	}
}
