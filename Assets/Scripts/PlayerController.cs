using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Which player is using the script
    public string inputID;

    private Rigidbody playerRb;

    [SerializeField] private float speed;
    [SerializeField] private float xBound = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move player based on input
        float horizontalInput = Input.GetAxis("Horizontal " + inputID);
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);

        // Keep player in bounds
        if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }
    }
}
