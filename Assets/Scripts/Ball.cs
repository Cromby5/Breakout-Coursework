using UnityEngine;

class Ball : MonoBehaviour
{
    // This variable exists so that the ball can be assigned to the spawner in the unity inspector 
    public BallSpawner spawner = null;
    //For the brick break audio 
    public AudioSource audioSource;

    //To set the defualt size and speed that can be edited in unity inspector if needed
    public float size = 1.0f;
    public float speed = 0.2f;

    protected float directionX = 1.0f;
    protected float directionY = 0.5f;


    protected virtual void FixedUpdate()
    {
        Vector3 scale = new Vector3();

        scale.x = size;
        scale.y = size;
        transform.localScale = scale;

        Vector3 position = transform.localPosition;
        position.x += speed * directionX;
        position.y += speed * directionY;
        transform.localPosition = position;
    }

 
    void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.name)
        {
            case "Bat":
            case "Top Wall":
                // Invert the direction vertically
                directionY = -directionY;   
                break;

            case "Left Wall":
            case "Right Wall":
                // Invert the direction horizonally 
                directionX = -directionX;  
                break;

            case "Kill Area":
                // Despawn the ball that touches the red area at the bottom of the screen   
                spawner.DespawnBall(this);
                // Lives will be decreased by 1 till no balls remain
                spawner.DecreaseLives();   
                break;
       
            case "Block(Clone)":
                // This will grab the points of the object we will collide with (block) 
                //and also transform the postion from local to world space as otherwise the x 
                //seems to be flipped which is confusing to keep track of
                var OtherPoints = transform.TransformPoint(other.transform.position);

                //Detects the right side being hit by checking if the x value of the ball is greater than the block 
                //and also checks if it higher than the block to avoid it triggering on the bottom side
                if (OtherPoints.x > transform.position.x && OtherPoints.y > transform.position.y)
                {
                    //Makes the ball go the other way on the x axis to prevent the ball going in a line taking out an entire row
                    directionX = -directionX;
                    //Default movement to make ball go back down towards bat
                    directionY = -directionY;
                }
                //Detects the left side being hit by checking if the x value of the ball is less than the block 
                //and also checks if it higher than the block to avoid it triggering on the bottom side
                else if (OtherPoints.x < transform.position.x && OtherPoints.y > transform.position.y)
                {
                    //Makes the ball go the other way on the x axis to prevent the ball going in a line taking out an entire row
                    directionX = -directionX;
                    //Default movement to make ball go back down towards bat
                    directionY = -directionY ;
                }
                else
                {
                    //Default movement to make ball go back down towards bat
                    directionY = -directionY;
                }

                //Play the break sound so you know you broke a block
                audioSource.Play();
                break;
                
            default:
                // If the ball has hit something not listed above, log a console message
                print(name + " has collided with " + other.gameObject.name);
                break;
        }
    }
    public void SetDirection(int angleInDegrees)
    {
        float angleInRadians = angleInDegrees * Mathf.Deg2Rad;
        directionX = Mathf.Cos(angleInRadians);
        directionY = Mathf.Sin(angleInRadians);
    }

}
