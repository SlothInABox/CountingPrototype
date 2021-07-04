using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody ballRb;

    [SerializeField] private float speed;
    [SerializeField] private float xBound;

    private Vector3 startPosition;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        ballRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        startPosition = transform.position;
        ballRb.velocity = Vector3.down * speed;
    }

    // Update is called once per frame
    void Update()
    {
        // Keep speed constant
        ballRb.velocity = ballRb.velocity.normalized * speed;

        // Keep ball in bounds
        if (transform.position.x < -xBound || transform.position.x > xBound)
        {
            ballRb.velocity = new Vector3(-ballRb.velocity.x, ballRb.velocity.y);
        }
    }

    // Bounce the ball off the player
    private void OnCollisionEnter(Collision collision)
    {
        // Bounce ball off player
        if (collision.collider.CompareTag("Player"))
        {
            float xVelocity = (transform.position.x - collision.transform.position.x) / collision.collider.bounds.size.x; // x velocity depends on where collision occurs
            ballRb.velocity = new Vector3(xVelocity, -(ballRb.velocity.y / ballRb.velocity.y)).normalized * speed;
        }
    }

    // Reset ball when it hits a sensor
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player 1 Sensor")
        {
            gameManager.UpdateScore(2);
        }
        else if (other.name == "Player 2 Sensor")
        {
            gameManager.UpdateScore(1);
        }

        transform.position = startPosition;
        ballRb.velocity = Vector3.down * speed;
    }
}
