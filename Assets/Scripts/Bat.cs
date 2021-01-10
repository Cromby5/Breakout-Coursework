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
        //Move Left
        if (isLeftPressed && canMoveLeft)
        {
            direction = -1.0f;
        }
        //Move Right
        else if (isRightPressed && canMoveRight)
        {
            direction = 1.0f;
        }
        //No Movement
        else
        {
            direction = 0.0f;
        }
        //Restart Game
        if (isRestartPressed)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        //To quit the game if you decided to bulid and run it
        else if (Input.GetKey("escape"))
        {
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



