using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public bool From_the_left { get; set; }

    private Rigidbody powerupRb;
    private float speed;
    private float xSpawnPos = 15.0f;
    private float ySpawnPos = 4.0f;


    // Start is called before the first frame update
    void Start()
    {
        powerupRb = GetComponent<Rigidbody>();
        speed = Random.Range(1.0f, 8.0f);

        // instantiate on the left
        if (Random.Range(0, 2) == 0)
        {
            From_the_left = true;
            gameObject.transform.position = new Vector3(-xSpawnPos, Random.Range(-ySpawnPos, ySpawnPos), 0);
            powerupRb.AddForce(Vector3.right * speed, ForceMode.Impulse);
            powerupRb.AddTorque(new Vector3(RandomTorque(), RandomTorque(), RandomTorque()), ForceMode.Impulse);
        }
        // instantiate on the right
        else
        {
            From_the_left = false;
            gameObject.transform.position = new Vector3(xSpawnPos, Random.Range(-ySpawnPos, ySpawnPos), 0);
            powerupRb.AddForce(Vector3.left * speed, ForceMode.Impulse);
            powerupRb.AddTorque(new Vector3(RandomTorque(), RandomTorque(), RandomTorque()), ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    float RandomTorque()
    {
        return Random.Range(-10.0f, 10.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("left bound") || other.CompareTag("right bound"))
        {
            Destroy(gameObject);
        }
    }

}
