using UnityEngine;

class Block : MonoBehaviour
{
    // This variable exists so that the block can be assigned to the spawner in the unity inspector 
    public BlockSpawner spawnerBlock = null;

    void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.name)
        {
            case "Ball(Clone)":
            case "CrazyBall(Clone)":
                //Destroys the block object that gets hit by the ball
                spawnerBlock.DespawnBlock(this); 
                break;
        }
    }

 }
