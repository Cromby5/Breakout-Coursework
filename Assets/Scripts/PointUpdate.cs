using UnityEngine;
using UnityEngine.UI;
public class PointUpdate : MonoBehaviour
{
    //To keep track of points +100 per ball
    int Points = 0;
    public Text PointsLabel = null;
    public void UpdatePoints()
    {
        //+100 points everytime
        Points = Points + 100;
        //Display
        PointsLabel.text = Points.ToString();
    }
}
