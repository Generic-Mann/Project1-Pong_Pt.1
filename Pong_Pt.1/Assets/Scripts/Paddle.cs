using System;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float maxPaddleSpeed = 1f;
    public bool isLeftPaddle = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float movementAxis = 0f;
        if (isLeftPaddle)
        {
            movementAxis = Input.GetAxis("LeftPaddle");
        }
        else
        {
            movementAxis = Input.GetAxis("RightPaddle");
        }

        Transform paddleTransform = GetComponent<Transform>();
        paddleTransform.position += new Vector3(0f, 0f, movementAxis * maxPaddleSpeed * Time.deltaTime);
    }
}
