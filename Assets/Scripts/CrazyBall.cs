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
        //This should give you back another crazy ball if it goes too crazy and flys off beyond the walls of the game
        if (transform.localPosition.y > 5 || transform.localPosition.x < -7 || transform.localPosition.x > 7)
        {
            //Despawn
            spawner.DespawnBall(this);
            //Spawn New crazy ball
            spawner.SpawnBall(spawner.crazyBallTemplate);
        }
    }
}