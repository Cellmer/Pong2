using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float speed;
    private Rigidbody ballRb;

    // Start is called before the first frame update
    void Start()
    {
        speed = 7.0f;
        ballRb = GetComponent<Rigidbody>();
        ballRb.AddForce(Random.insideUnitCircle.normalized * speed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        // maintain constant velocity
        ballRb.velocity = speed * (ballRb.velocity.normalized);
    }
}
