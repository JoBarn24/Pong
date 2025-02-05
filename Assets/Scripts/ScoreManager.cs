using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
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
            UpdateScoreText();
        }
    }
    private void AddPointToLeft()
    {
        leftScore++;
    }

    private void AddPointToRight()
    {
        rightScore++;
    }

    private void UpdateScoreText()
    {
        scoreText.text = leftScore + " | " + rightScore;
    }
}
