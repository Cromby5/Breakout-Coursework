using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This class defines a component which can spawn new game objects by creating copies
// of a template game object which already exists in the scene.
class BallSpawner : MonoBehaviour
{
    // This variable should be set in the Inspector to an inactive Text object containing
    // the text to display when the game is over.
    public Text gameOver = null;
    //To show the text box showing the player the button to restart
    public Text Restart = null;
    //Storing Lives
    public int Lives = 3;
    //To be assigned to ingame counter of Lives
    public Text LivesLabel = null;

    // This variable should be set in the Inspector to an existing ball object within
    // the scene. The template object can, and probably should be an inactive object.
    public Ball ballTemplate = null;
    //Crazy Ball will appear after 2 balls are lost
    public CrazyBall crazyBallTemplate = null;
    // List to keep track of all balls spawned by this script.
    List<Ball> ballList = new List<Ball>();

    void Start()
    {
            //Spawn the 1st Ball
            SpawnBall(ballTemplate);
    }

    void SpawnBall(Ball templateToCopy)
    {

        Ball ballClone = Instantiate(templateToCopy);

        // Move the new ball clone to the ball spawner's position
        // ballClone.transform.position = transform.position;

        // Generate a random direction for the ball clone
        int angle = Random.Range(20, 160);
        //To prevent the ball going straight up
        if (angle == 90)
        {
            angle =+ 20;
        }
        ballClone.SetDirection(angle);

        // Activate the new ball clone
        ballClone.gameObject.SetActive(true);

        // Add the new ball clone to the list of balls
        ballList.Add(ballClone);
    }

    public void DespawnBall(Ball ballToDespawn)
    {
        // Remove the ball from the list of balls
        ballList.Remove(ballToDespawn);
        // Destroy the ball game object
        Destroy(ballToDespawn.gameObject);

        if (Lives == 1)
        {
            //If Lives remain spawn a new ball
            SpawnBall(crazyBallTemplate);
        }
        else if (Lives > 0)
            SpawnBall(ballTemplate);
        else
        {
            // Show the game over text if there are no balls remaining in Lives
            LivesLabel.gameObject.SetActive(false);
            gameOver.gameObject.SetActive(true);
            //Shows "Backspace to Restart" text
            Restart.gameObject.SetActive(true);
        }
    }
    public void DecreaseLives()
    {
        //Decrease Lives by 1
        Lives = Lives - 1;
        //Shows Balls Remaining in game 
        LivesLabel.text = Lives.ToString();
    }


}

