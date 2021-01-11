using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This class defines a component which can spawn new game objects by creating copies
// of a template game object which already exists in the scene.
class BlockSpawner : MonoBehaviour
{
    //Shows Current Level
     int Level = 1;
    //For showing level number in game
    public Text LevelLabel = null;
    // This variable should be set in the Inspector to an existing ball object within
    // the scene. The template object can, and probably should be an inactive object.
    public Block blocktemplate = null;

    //The Amount of rows the blocks should spawn in (Y values) unless changed in unity
    public int rows = 4;
    //The Amount of columns the blocks should spawn in (X values) unless changed in unity
    public int columns = 4;
    //Random number to destory
    int r = 0;
    // List to keep track of all balls spawned by this script.
    List<Block> blockList = new List<Block>();

    void Start()
    {
        //Start the process of spawning blocks
        SpawnBlock(blocktemplate);
    }

    void SpawnBlock(Block templateToCopy)
    {
        //Give blocks a postion in the grid by giving them a x and y value  e.g. (1,2) (1,3) (3,1) until no more rows and columns are left
        for (int x = 0; x < columns; x++)
         {
           for(int y = 0; y < rows; y++)
           { 
                //Gets Random Number
                r = Random.Range(2, 4);
                //If it is 3 skip this block from spawning in
                if (r == 3)
                {
           
                }
                else
                {
                    //Making a Block with the current x and y values but x is -5 
                    //cause 0,0 is the camera location and so the left side of the play area isnt left out
                    Block blockClone = Instantiate(templateToCopy, new Vector2(x - 5, y), Quaternion.identity);
                    //Enables the block object
                    blockClone.gameObject.SetActive(true);
                    //Add the block to the list 
                    blockList.Add(blockClone);
                }
           }
         }
    }
    public void DespawnBlock(Block blockToDespawn)
    {
        // Remove the block from the list of blocks
           blockList.Remove(blockToDespawn);
        // Destroy the block game object
        Destroy(blockToDespawn.gameObject);
        // Show the "Level Complete" text if there are no blocks remaining
     if (blockList.Count == 0)
        {
            //Start the Next Level Coroutine
            StartCoroutine("NextLevel");
        }
    }

    IEnumerator NextLevel()
    {
        //Show "Complete" below Level for 2 seconds
        LevelLabel.text = "Complete";
        yield return new WaitForSeconds(2f);
        //Switch Level
        Level = Level + 1;
        LevelLabel.text = Level.ToString();
        //Put blocks back in but make it random how many blocks you will get by changing the rows and colunms to fill
        rows = Random.Range(1, 5);
        columns = Random.Range(1, 11);
        //Spawn the new set of blocks with the new amount of rows and columns 
        SpawnBlock(blocktemplate);
        //Stop This Coroutine
        StopCoroutine("NextLevel");
    }
}
