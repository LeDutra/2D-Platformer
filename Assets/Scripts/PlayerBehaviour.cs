using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public GameObject player;
    public float smoothness;
    public float initialMovement;
    public float maxSpeed;
    private Transform playerPosition;
    private Rigidbody2D playerBody;
    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        playerPosition = player.GetComponent<Transform>();
        playerBody = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("W");
            GoUp();
        }

        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("A");
            GoLeft();
        }

        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("D");
            GoRight();
        }
    }

    private void GoUp()
    {
        if (playerBody.velocity.y <= 0)
            playerBody.velocity = new Vector2(playerBody.velocity.x, initialMovement);
        playerBody.velocity = new Vector2(playerBody.velocity.x, playerBody.velocity.y * smoothness);

        if (playerBody.velocity.y > maxSpeed)
            playerBody.velocity = new Vector2(playerBody.velocity.x, maxSpeed);
    }

    private void GoRight()
    {
        if (playerBody.velocity.x <= 0)
            playerBody.velocity = new Vector2(initialMovement, playerBody.velocity.y);
        playerBody.velocity = new Vector2(playerBody.velocity.x * smoothness, playerBody.velocity.y);

        if (playerBody.velocity.x > maxSpeed)
            playerBody.velocity = new Vector2(maxSpeed, playerBody.velocity.y);
    }

    private void GoLeft()
    {
        if (playerBody.velocity.x >= 0)
            playerBody.velocity = new Vector2(-initialMovement, playerBody.velocity.y);
        playerBody.velocity = new Vector2(playerBody.velocity.x * smoothness, playerBody.velocity.y);

        if (playerBody.velocity.x < -maxSpeed)
            playerBody.velocity = new Vector2(-maxSpeed, playerBody.velocity.y);
    }
}
