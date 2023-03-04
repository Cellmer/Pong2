using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupsHandler : MonoBehaviour
{
    public bool hasFastBallPowerup = false;
    public bool hasLongPaddlePowerup = false;
    public bool hasSlowPaddlePowerup = false;

    public Material standardMaterial;
    public Material fastBallMaterial;
    public Material longPaddleMaterial;
    public Material slowPaddleMaterial;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.GetComponent<Powerup>().from_the_left && gameObject.CompareTag("left paddle")) ||
            (!other.gameObject.GetComponent<Powerup>().from_the_left && gameObject.CompareTag("right paddle")))
            return;

        if (other.CompareTag("powerup fast ball") && !hasFastBallPowerup)
        {
            StartCoroutine(SpawnFastBallPaddle());
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("powerup long paddle") && !hasLongPaddlePowerup)
        {
            StartCoroutine(SpawnLongPaddle());
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("powerup slow paddle") && !hasSlowPaddlePowerup)
        {
            StartCoroutine(SpawnSlowPaddle());
            Destroy(other.gameObject);
        }
    }

    IEnumerator SpawnFastBallPaddle()
    {
        if (hasLongPaddlePowerup)
        {
            gameObject.transform.localScale -= Vector3.up * 2;
            hasLongPaddlePowerup = false;
        }
        if (hasSlowPaddlePowerup)
        {
            gameObject.GetComponent<Speed>().speed *= 2.0f;
            hasSlowPaddlePowerup = false;
        }

        gameObject.GetComponent<MeshRenderer>().material = fastBallMaterial;
        hasFastBallPowerup = true;

        yield return new WaitForSeconds(10.0f);

        if (hasFastBallPowerup)
        {
            gameObject.GetComponent<MeshRenderer>().material = standardMaterial;
            hasFastBallPowerup = false;
        }
    }

    IEnumerator SpawnLongPaddle()
    {
        hasFastBallPowerup = false;
        if (hasSlowPaddlePowerup)
        {
            gameObject.GetComponent<Speed>().speed *= 2.0f;
            hasSlowPaddlePowerup = false;
        }

        gameObject.GetComponent<MeshRenderer>().material = longPaddleMaterial;
        gameObject.transform.localScale += Vector3.up * 2;
        hasLongPaddlePowerup = true;

        yield return new WaitForSeconds(10.0f);

        if (hasLongPaddlePowerup)
        {
            gameObject.GetComponent<MeshRenderer>().material = standardMaterial;
            gameObject.transform.localScale -= Vector3.up * 2;
            hasLongPaddlePowerup = false;
        }
    }

    IEnumerator SpawnSlowPaddle()
    {
        if (hasLongPaddlePowerup)
        {
            gameObject.transform.localScale -= Vector3.up * 2;
            hasLongPaddlePowerup = false;
        }
        hasFastBallPowerup = false;

        gameObject.GetComponent<MeshRenderer>().material = slowPaddleMaterial;
        gameObject.GetComponent<Speed>().speed /= 2.0f;
        hasSlowPaddlePowerup = true;

        yield return new WaitForSeconds(10.0f);

        if (hasSlowPaddlePowerup)
        {
            gameObject.GetComponent<MeshRenderer>().material = standardMaterial;
            gameObject.GetComponent<Speed>().speed *= 2.0f;
            hasSlowPaddlePowerup = false;
        }
    }
}
