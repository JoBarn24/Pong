using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI rightScoreText;
    public TextMeshProUGUI leftScoreText;
    public GameObject ball;

    private int leftScore = 0;
    private int rightScore = 0;

    private void OnTriggerEnter(Collider other)
    {
        BallScript ballScript = ball.GetComponent<BallScript>();
        
        if (other.CompareTag("Ball"))
        {
            if (gameObject.name == "LeftGoal")
            {
                AddPointToRight();
                Debug.Log("Left player scored! Score: " + leftScore.ToString() + " | " + rightScore.ToString());
                ballScript.ResetBall("right");
            }
            else if (gameObject.name == "RightGoal")
            {
                AddPointToLeft();
                Debug.Log("Right player scored! Score: " + leftScore.ToString() + " | " + rightScore.ToString());
                ballScript.ResetBall("left");
            }
        }
    }
    private void AddPointToLeft()
    {
        leftScore++;
        leftScoreText.text = leftScore.ToString();
        Debug.Log(leftScore);
    }

    private void AddPointToRight()
    {
        rightScore++;
        rightScoreText.text = rightScore.ToString();
        Debug.Log(rightScore);
    }
}
