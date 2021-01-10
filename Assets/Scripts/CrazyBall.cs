using UnityEngine;

class CrazyBall : Ball
{
    //The last ball will be one of these crazy balls
    protected override void FixedUpdate()
    {
        // Every frame, there will be a 2% chance of this if statement being true
        if (Random.Range(0, 100) <= 2)
        {
            //Change Size 
            size = Random.Range(1f, 3f);
            //Change Speed
            speed = Random.Range(0.2f, 0.5f);
        }
        // Call the FixedUpdate method defined in the Ball class
        base.FixedUpdate();  
    }

}