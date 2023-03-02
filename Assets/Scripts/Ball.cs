using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Rigidbody ballRb;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        ballRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        System.Random rnd = new System.Random();
        ballRb.AddForce(new Vector3(2 * rnd.Next(0, 1) - 1, Random.Range(-2, 2)) * speed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        // maintain constant velocity
        ballRb.velocity = speed * (ballRb.velocity.normalized);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("left bound"))
        {
            Destroy(gameObject);
            gameManager.UpdateRightPlayerScore();
            gameManager.ThrowBall();
        }
        else if(other.CompareTag("right bound"))
        {
            Destroy(gameObject);
            gameManager.UpdateLeftPlayerScore();
            gameManager.ThrowBall();
        }
    }

}
