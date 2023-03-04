using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    private float verticalInput;
    private float horizontalInput;
    private Rigidbody playerRb;

    private float speed;
    private float rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = gameObject.GetComponent<Speed>().speed;
        rotateSpeed = gameObject.GetComponent<Speed>().rotateSpeed;
        verticalInput = Input.GetAxis("Vertical2");
        horizontalInput = Input.GetAxis("Horizontal2");
        transform.Translate(Vector3.up * Time.deltaTime * speed * verticalInput, Space.World);
        transform.Rotate(Vector3.back, rotateSpeed * horizontalInput);

        // freeze if player doesn't press any key
        if (verticalInput == 0.0f)
        {
            playerRb.velocity = Vector3.zero;
        }
    }
}
