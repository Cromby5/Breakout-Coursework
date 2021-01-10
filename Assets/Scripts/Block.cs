using UnityEngine;

class Block : MonoBehaviour
{
    // This variable exists so that the block can be assigned to the spawner in the unity inspector 
    public BlockSpawner spawnerBlock = null;

    //My random Block Colours Green and Purple will be selected
    public Sprite BlockG;
    public Sprite BlockP;

    void Start()
    {
        //Random number that will be 0 or 1
        int b = Random.Range(0, 2);
        //If 0 The block is green
        if (b == 0)
        {
            this.GetComponent<SpriteRenderer>().sprite = BlockG;
        }
        //If 1 The block is purple
        else if (b == 1)
        {
            this.GetComponent<SpriteRenderer>().sprite = BlockP;

        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //Switch case using the names of the gameobjects
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
