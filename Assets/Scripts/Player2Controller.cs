using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    private float verticalInput;
    private float horizontalInput;
    private float speed = 4.0f;
    private float rotateSpeed = 0.5f;
    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical2");
        horizontalInput = Input.GetAxis("Horizontal2");
        transform.Translate(Vector3.up * Time.deltaTime * speed * verticalInput, Space.World);
        transform.Rotate(Vector3.back, rotateSpeed * horizontalInput);
    }
}
