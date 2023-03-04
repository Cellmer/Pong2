using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComputerEasyController : MonoBehaviour
{
    private float speed;
    private float rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        speed = gameObject.GetComponent<Speed>().speed;
        rotateSpeed = gameObject.GetComponent<Speed>().rotateSpeed;
        GameObject ball = GameObject.FindGameObjectWithTag("ball");
        if(ball.transform.position.y > gameObject.transform.position.y)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed, Space.World);
            transform.Rotate(Vector3.back, rotateSpeed);
        }
        else
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed, Space.World);
            transform.Rotate(Vector3.forward, rotateSpeed);
        }
        
        
    }
}
