using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComputerHardController : MonoBehaviour
{

    private float speed;
    private float rotateSpeed;

    private float xBound = 12.0f;
    private float yBound = 6.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = gameObject.GetComponent<Speed>().MovingSpeed;
        rotateSpeed = gameObject.GetComponent<Speed>().RotateSpeed;
        GameObject ball = GameObject.FindGameObjectWithTag("ball");
        if (ball && isInBounds(ball))
        {
            if (ball.transform.position.y > gameObject.transform.position.y)
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

    bool isInBounds(GameObject ball)
    {
        if (ball.transform.position.y >= yBound || ball.transform.position.y <= -yBound || ball.transform.position.x < -xBound || ball.transform.position.x > xBound)
            return false;
        return true;
    }
}
