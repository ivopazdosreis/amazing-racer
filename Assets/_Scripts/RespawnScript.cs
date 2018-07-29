using UnityEngine;
using System.Collections;

public class RespawnScript : MonoBehaviour {
	
	//Place holder for the spawn point
	public Transform respawnPoint;
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
	
	//This fires off when the player enters
	//the water hazard
	void OnTriggerEnter(Collider other)
	{
		//Moves the player to the spawn point
		other.gameObject.transform.position = respawnPoint.position;
	}
}
