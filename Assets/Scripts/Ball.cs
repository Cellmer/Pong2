using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Rigidbody ballRb;
    private GameManager gameManager;
    private bool hasPowerup = false;

    public Material standardMaterial;
    public Material powerupMaterial;

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
            if(collision.gameObject.GetComponent<PowerupsHandler>().hasFastBallPowerup)
            {
                StartCoroutine(ApplyPowerup());
            }
        }
    }

    IEnumerator ApplyPowerup()
    {
        hasPowerup = true;
        speed *= 2.0f;
        gameObject.GetComponent<MeshRenderer>().material = powerupMaterial;
        yield return new WaitForSeconds(10.0f);

        speed /= 2.0f;
        gameObject.GetComponent<MeshRenderer>().material = standardMaterial;
        hasPowerup = false;
    }

}
