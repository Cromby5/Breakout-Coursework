using UnityEngine;
using UnityEngine.SceneManagement;
class Bat : MonoBehaviour
{
    //Setting our left and right movement keys for the bat
    public KeyCode moveLeftKey = KeyCode.LeftArrow;
    public KeyCode moveRightKey = KeyCode.RightArrow;
    //Setting Restart Key to restart the game
    public KeyCode RestartKey = KeyCode.Backspace;
    //Booleans that will be used to determine if the bat can move left or right
    bool canMoveLeft = true;
    bool canMoveRight = true;
    //The speed the bat will move at
    public float speed = 0.2f;
    //Making and setting the base direction the bat is going to be 0
    float direction = 0.0f;
    //For sound when a ball hits the bat
    public AudioSource audioBat;

    void FixedUpdate()
    {
        //Sets the Bats position
        Vector3 position = transform.localPosition;
        //Speed*direction will make the bat move smoothly in the current direction
        position.x += speed * direction;
        //Set the local position to the position 
        transform.localPosition = position;
    }

    void Update()
    {
        //True/False for is key pressed
        bool isLeftPressed = Input.GetKey(moveLeftKey);
        bool isRightPressed = Input.GetKey(moveRightKey);
        bool isRestartPressed = Input.GetKey(RestartKey);
       
        if (isLeftPressed && canMoveLeft)
        {
            //Move Left
            direction = -1.0f;
        }
        else if (isRightPressed && canMoveRight)
        {
            //Move Right
            direction = 1.0f;
        }
        else
        {
            //No Movement
            direction = 0.0f;
        }
        //Restart Game
        if (isRestartPressed)
        {
            //Reloads the scene as if you started the game again
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (Input.GetKey("escape"))
        {
            //To quit the game if you decided to bulid and run it
            Application.Quit();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //Switch case using the names of the gameobjects
        switch (other.gameObject.name)
        {
            //This will stop the bat from moving left when it hits the left wall
            case "Left Wall":
                canMoveLeft = false;
                break;
            //This will stop the bat from moving left when it hits the right wall
            case "Right Wall":
                canMoveRight = false;
                break;
            case "Ball(Clone)":
            case "CrazyBall(Clone)":
                //Play the bat hit sound
                audioBat.Play();
                break;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        //Switch case using the names of the gameobjects
        switch (other.gameObject.name)
        {
            //When they exit the collision zone of the left wall they can move left again
            case "Left Wall":
                canMoveLeft = true;
                break;
            //When they exit the collision zone of the right wall they can move right again
            case "Right Wall":
                canMoveRight = true;
                break;
        }
    }
}



