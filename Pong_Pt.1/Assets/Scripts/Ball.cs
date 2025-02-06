using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Ball : MonoBehaviour
{
    Rigidbody rbody;
    public float speed = 1f;
    private int leftScore; 
    private int rightScore;
    private bool leftScored = true;
    public TextMeshProUGUI leftScoreText;
    public TextMeshProUGUI rightScoreText;
    public Vector3 startPosition;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        leftScore = 0;
        rightScore = 0;
        startPosition = transform.position;

        rbody.linearVelocity = new Vector3(1f, 0f, 0f) * speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        rbody = GetComponent<Rigidbody>();

        if (other.gameObject.CompareTag("LeftPaddle") || other.gameObject.CompareTag("RightPaddle"))
        {
            speed = speed * 1.5f; 
        }

        Vector3 newVelocity = other.relativeVelocity;
        newVelocity = newVelocity.normalized * speed;

        rbody.linearVelocity = newVelocity.normalized;

        if (other.gameObject.CompareTag("LeftScore"))
        {
            rightScore++;
            Debug.Log("Right player scored! Score: " + leftScore + " - " + rightScore);
            leftScored = false;
            SetCountText();
            resetBall();
        }
        else if (other.gameObject.CompareTag("RightScore"))
        {
            leftScore++;
            Debug.Log("Left player scored! Score: " + leftScore + " - " + rightScore);
            leftScored = true;
            SetCountText();
            resetBall();
        }
    }

    void SetCountText() 
    {
        leftScoreText.text = leftScore.ToString();
        rightScoreText.text = rightScore.ToString();

        if (leftScore == 10 || rightScore == 10)
        {
            if (leftScore == 10){
                Debug.Log("Game Over, Left Paddle Wins!");
            } 
            else if (rightScore == 10)
            {
                Debug.Log("Game Over, Right Paddle Wins!");
            }
            leftScore = 0;
            rightScore = 0;
        }
    }

    void resetBall()
    {
        transform.position = startPosition;  
        rbody.linearVelocity = Vector3.zero;

        if (leftScored)
        {
            rbody.linearVelocity = new Vector3(1f, 0f, 0f) * speed;
        }
        else
        {
            rbody.linearVelocity = new Vector3(-1f, 0f, 0f) * speed;
        }
    }
}
