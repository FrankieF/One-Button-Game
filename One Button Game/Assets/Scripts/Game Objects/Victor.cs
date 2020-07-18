using UnityEngine;
using System.Collections;

public class Victor : MonoBehaviour
{
	// Move speed for Victor
	protected float moveSpeed = 2f;
	public Rigidbody body;
	
	// Lives for player
	public int PlayerLives = 3;
	
	// Checks to see if Victor has treasure to slow him down
	private bool Treasure = false;	
	// Weight increases per level from the treausre slowing Victor down
	protected float Weight = .45f;
	
	// MoveDown becomes the equal of pressing space bar
	protected KeyCode MoveDown = KeyCode.Space;

    private float spinTime = .5f;
    private float spinTimer = 0f;
	
	public GameLogic gameLogic;
	
	void Start ()
	{
		GameObject gameLogicGameObject = GameObject.Find("GameLogic");
		if (gameLogicGameObject!=null)
		{
			Component gameLogicComponent = gameLogicGameObject.GetComponent ("GameLogic");
			
			if (gameLogicComponent != null)
			{
				gameLogic = gameLogicGameObject.GetComponent("GameLogic") as GameLogic;
			}
		}
	}	
	
	void Update ()
	{
		Movement();
	}
	
	// Movement function to check if Space Bar is pressed
	// Victor will move up unless the button is pressed
	// This moves Victor down
	private void Movement()
	{
		body.velocity = Vector3.zero;
		
		if (Input.GetKey(MoveDown))
		{
            if (spinTimer < spinTime)

			body.velocity = Vector3.forward * moveSpeed;
		}
		else 
		{
			body.velocity = -Vector3.forward * moveSpeed;
		}
	}
	
	private void OnCollisionEnter(Collision collider)
	{
		if(collider.collider.name.EndsWith("Shark"))
		{
			//Victor Dies
			Destroy(gameObject);
			gameLogic.GameOver();
		}
		
		if (collider.collider.name.EndsWith("Sea Monster"))
		{
			//Victor dies
			Destroy(gameObject);
			gameLogic.GameOver();
		}
		if (collider.collider.name.EndsWith("YellowFish"))
		{
			// score increases by 25
			gameLogic.PlayerScore += 250;
			Destroy(collider.gameObject);
		}
		if (collider.collider.name.EndsWith("GreenFish"))
		{
			// score increases by 50
			gameLogic.PlayerScore += 500;
			Destroy(collider.gameObject);
		}
		if (collider.collider.name.EndsWith("TriggerVolume"))
		{
			// victor beats the level
		}
		if (collider.collider.name.EndsWith("Treasure"))
		{
			// victor has treausre and will move slower
			Destroy(collider.gameObject);
			Treasure=true;
			gameLogic.PlayerScore += 1000;
			moveSpeed -= Weight;
		}
		
		if (Treasure)
		{
			// If victor collides with the boat and has the treasure his score goes up and player wins plays, stopping player movement
			if (collider.collider.name.EndsWith("Boat"))
			{
				gameLogic.PlayerWins=true;
				gameLogic.PlayerScore += 10000;
			}
		}		
	}
}
