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

        System.Random random = new System.Random();
        ballRb.AddForce(new Vector3(2 * Random.Range(0, 2) - 1, ((float)random.NextDouble() - 0.5f) * 4) * speed, ForceMode.Impulse);
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
