using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float verticalInput;
    private float horizontalInput;
    private float speed = 5.0f;
    private float rotateSpeed = 0.8f;
    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.up * Time.deltaTime * speed * verticalInput, Space.World);
        transform.Rotate(Vector3.back, rotateSpeed * horizontalInput);

        // freeze if player doesn't press any key
        if (verticalInput == 0.0f)
        {
            playerRb.velocity = Vector3.zero;
        }
    }
}
