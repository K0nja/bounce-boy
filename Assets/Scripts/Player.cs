using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{

    public float movementSpeed = 10f;
    float movement = 0f;
    Rigidbody2D rb;
    public Text scoreText;
    private float topScore = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
    }

    void FixedUpdate()
    {
        CheckIfOffScreen();
        KeyboardMovement();
        //MobileMovement();
    }

    void UpdateScore()
    {
        if (rb.velocity.y > 0 && transform.position.y > topScore)
        {
            topScore = transform.position.y;
            PlayerPrefs.SetInt("Score", (int)Mathf.Round(topScore));
        }

        scoreText.text = "Score: " + Mathf.Round(topScore).ToString();
    }

    void CheckIfOffScreen()
    {
        if (transform.position.x > 3 || transform.position.x < -3)
        {
            transform.position = new Vector2(transform.position.x * -1, transform.position.y);
        }
    }

    void KeyboardMovement()
    {
        movement = Input.GetAxis("Horizontal") * movementSpeed;
        Vector2 velocity = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;
    }

    void MobileMovement()
    {
        movement = Input.acceleration.x * movementSpeed;
        Vector2 velocity = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;
    }

}
