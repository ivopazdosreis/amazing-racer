using UnityEngine;
using System.Collections;

public class FinishScript : MonoBehaviour {
	
	//This is a place holder for the script that controls the game
	public GameControlScript gameControlScript;
	
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
	
	
	//This states that when an object enters the finish zone, let the
	//game control know that the current game has ended
	void OnTriggerEnter(Collider other)
	{
		gameControlScript.FinishedGame();
	}
}
