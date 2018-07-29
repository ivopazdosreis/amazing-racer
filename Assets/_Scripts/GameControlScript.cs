using UnityEngine;
using System.Collections;

public class GameControlScript : MonoBehaviour
{
    //The amount of ellapsed time
    private float time = 0;

    //Flags that control the state of the game
    private bool isRunning = false;
    private bool isFinished = false;

    //place holders for the player and the spawn point
    public Transform spawnPoint;
    public GameObject player;

    //place holders for the scripts on the character controller
    public CharacterMotor motorScript;
    public MouseLook lookScript;

    //This resets to game back to the way it started
    private void InitLevel()
    {
        time = 0;
        isRunning = true;
        isFinished = false;

        //move the player to the spawn point
        player.transform.position = spawnPoint.position;

        //Allow the character controller to move and
        //look around
        motorScript.enabled = true;
        lookScript.enabled = true;
    }

    // Use this for initialization
    void Start()
    {

        //prevent the character controller
        //from looking around
        motorScript.enabled = false;
        lookScript.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        //add time to the clock if the game
        //is running
        if (isRunning)
        {
            time += Time.deltaTime;
        }
    }

    //This runs when the player enters the finish
    //zone
    public void FinishedGame()
    {
        isRunning = false;
        isFinished = true;

        //freeze the character controller
        motorScript.enabled = false;
        lookScript.enabled = false;
    }


    //This section creates the Graphical User Interface (GUI)
    void OnGUI()
    {

        if (!isRunning)
        {
            string message;
            if (isFinished)
            {
                message = "Click to Play Again";
            }
            else
            {
                message = "Click to Play";
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 70, Screen.height / 2, 140, 30), message))
            {
                //start the game if the user clicks to play
                InitLevel();
            }
        }

        //If the player finished the game, show the final time
        if (isFinished)
        {
            GUI.Box(new Rect(Screen.width / 2 - 65, 185, 130, 40), "Your Time Was");
            GUI.Label(new Rect(Screen.width / 2 - 10, 180, 25, 30), ((int)time).ToString());
        }
        //If the game is running, show the current time
        else if (isRunning)
        {
            GUI.Box(new Rect(Screen.width / 2 - 65, Screen.height - 115, 130, 40), "Your Time Is");
            GUI.Label(new Rect(Screen.width / 2 - 10, Screen.height - 100, 20, 30), ((int)time).ToString());
        }
    }
}
