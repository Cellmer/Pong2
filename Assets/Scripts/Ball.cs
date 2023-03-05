using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private Material standardMaterial;

    [SerializeField]
    private Material powerupMaterial;

    private Rigidbody ballRb;
    private GameManager gameManager;
    private bool hasPowerup = false;
    private float speedIncreaseFactor;
    private float powerupDuration;

    // Start is called before the first frame update
    void Start()
    {
        speedIncreaseFactor = 2.0f;
        powerupDuration = 10.0f;
        ballRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        ballRb.AddForce(RandomDirection() * speed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        // maintain constant velocity
        ballRb.velocity = speed * (ballRb.velocity.normalized);
    }

    Vector3 RandomDirection()
    {
        System.Random random = new System.Random();
        return new Vector3(2 * Random.Range(0, 2) - 1, ((float)random.NextDouble() - 0.5f) * 4).normalized;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("left bound"))
        {
            gameManager.UpdateRightPlayerScore();
            StartCoroutine(gameManager.ThrowBall(gameObject));
        }
        else if(other.CompareTag("right bound"))
        {
            gameManager.UpdateLeftPlayerScore();
            StartCoroutine(gameManager.ThrowBall(gameObject));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (hasPowerup)
            return;

        if(collision.gameObject.CompareTag("left paddle") || collision.gameObject.CompareTag("right paddle"))
        {
            if(collision.gameObject.GetComponent<PowerupsHandler>().HasFastBallPowerup)
            {
                StartCoroutine(ApplyPowerup());
            }
        }
    }

    IEnumerator ApplyPowerup()
    {
        hasPowerup = true;
        speed *= speedIncreaseFactor;
        gameObject.GetComponent<MeshRenderer>().material = powerupMaterial;
        yield return new WaitForSeconds(powerupDuration);

        speed /= speedIncreaseFactor;
        gameObject.GetComponent<MeshRenderer>().material = standardMaterial;
        hasPowerup = false;
    }

}
