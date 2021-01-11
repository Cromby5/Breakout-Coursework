using UnityEngine;
using UnityEngine.UI;
public class PointUpdate : MonoBehaviour
{
    //To keep track of points
    int Points = 0;
    public Text PointsLabel = null;
    public void UpdatePoints()
    {
        //+100 points everytime a block is hit for that ball
        Points += 100;
        //Display the current total points on this life
        PointsLabel.text = Points.ToString();
    }
}
