using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour
{
	// Players starting score
	public float PlayerScore = 0;
	
	//Checks to see if game is over
	private bool EndGame;
	
	// Checks to see if the player won the game
	public bool PlayerWins;
	
	// Creates Victor in the script to be referenced 
	private Victor victor;
	
	// Creates timer to calculate playerScore
	private float timer;

	
	void Start ()
	{
		
	}
	
	void OnGUI()
	{
		if (EndGame)
		{	
			// Asks the player to play again
			if (GUILayout.Button("Play Again?"))
			{
				Application.LoadLevel("Descent");
			}			
		}
		
		// If the player reaches the top with the treasure it will tell them they won
		if(PlayerWins)
		{
			// Puts text in the middle of the screen
			float ScreenHeight = Screen.height * .5f;
			float ScreenWidth = Screen.width * .5f;
				
			GUI.Label(new Rect (ScreenWidth, ScreenHeight, 150, 100), "YOU WIN!");
			
			// Asks the player to play again
			if (GUILayout.Button("Play Again?"))
			{
				Application.LoadLevel("Descent");
			}
		}
			
		// Displays players current score
		else
		{		
			PlayerScore += timer * 0.5f;
			GUILayout.Label("Score: " + Mathf.FloorToInt(PlayerScore));
		}
	}
	void Update ()
	{
		// Timer takes in the game time to calculate playerScore
		timer = Time.deltaTime;
		
	}
	// Sets EndGame to true to run the play again button
	public void GameOver()
	{
		EndGame=true;
	}

}
