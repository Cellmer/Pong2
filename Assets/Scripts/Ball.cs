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
        speed = 3.0f;
        ballRb = GetComponent<Rigidbody>();
        ballRb.AddForce(Random.insideUnitCircle.normalized * speed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
