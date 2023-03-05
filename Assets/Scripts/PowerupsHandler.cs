using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupsHandler : MonoBehaviour
{
    public bool HasFastBallPowerup { get; set; }
    public bool HasLongPaddlePowerup { get; set; }
    public bool HasSlowPaddlePowerup { get; set; }

    private float paddleScalingFactor = 2.0f;
    private float paddleSlowingFactor = 2.0f;
    private float powerupDuration = 10.0f;

    // materials
    [SerializeField]
    private Material standardMaterial;

    [SerializeField]
    private Material fastBallMaterial;

    [SerializeField]
    private Material longPaddleMaterial;

    [SerializeField]
    private Material slowPaddleMaterial;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // on collision with powerup
    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.GetComponent<Powerup>().From_the_left && gameObject.CompareTag("left paddle")) ||
            (!other.gameObject.GetComponent<Powerup>().From_the_left && gameObject.CompareTag("right paddle")))
            return;

        if (other.CompareTag("powerup fast ball") && !HasFastBallPowerup)
        {
            StartCoroutine(ApplyFastBallPaddlePowerup());
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("powerup long paddle") && !HasLongPaddlePowerup)
        {
            StartCoroutine(ApplyLongPaddlePowerup());
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("powerup slow paddle") && !HasSlowPaddlePowerup)
        {
            StartCoroutine(ApplySlowPaddlePowerup());
            Destroy(other.gameObject);
        }
    }

    IEnumerator ApplyFastBallPaddlePowerup()
    {
        if (HasLongPaddlePowerup)
        {
            gameObject.transform.localScale -= Vector3.up * paddleScalingFactor;
            HasLongPaddlePowerup = false;
        }
        if (HasSlowPaddlePowerup)
        {
            gameObject.GetComponent<Speed>().MovingSpeed *= paddleSlowingFactor;
            HasSlowPaddlePowerup = false;
        }

        gameObject.GetComponent<MeshRenderer>().material = fastBallMaterial;
        HasFastBallPowerup = true;

        yield return new WaitForSeconds(powerupDuration);

        if (HasFastBallPowerup)
        {
            gameObject.GetComponent<MeshRenderer>().material = standardMaterial;
            HasFastBallPowerup = false;
        }
    }

    IEnumerator ApplyLongPaddlePowerup()
    {
        HasFastBallPowerup = false;
        if (HasSlowPaddlePowerup)
        {
            gameObject.GetComponent<Speed>().MovingSpeed *= paddleSlowingFactor;
            HasSlowPaddlePowerup = false;
        }

        gameObject.GetComponent<MeshRenderer>().material = longPaddleMaterial;
        gameObject.transform.localScale += Vector3.up * paddleScalingFactor;
        HasLongPaddlePowerup = true;

        yield return new WaitForSeconds(powerupDuration);

        if (HasLongPaddlePowerup)
        {
            gameObject.GetComponent<MeshRenderer>().material = standardMaterial;
            gameObject.transform.localScale -= Vector3.up * paddleScalingFactor;
            HasLongPaddlePowerup = false;
        }
    }

    IEnumerator ApplySlowPaddlePowerup()
    {
        if (HasLongPaddlePowerup)
        {
            gameObject.transform.localScale -= Vector3.up * paddleScalingFactor;
            HasLongPaddlePowerup = false;
        }
        HasFastBallPowerup = false;

        gameObject.GetComponent<MeshRenderer>().material = slowPaddleMaterial;
        gameObject.GetComponent<Speed>().MovingSpeed /= paddleSlowingFactor;
        HasSlowPaddlePowerup = true;

        yield return new WaitForSeconds(powerupDuration);

        if (HasSlowPaddlePowerup)
        {
            gameObject.GetComponent<MeshRenderer>().material = standardMaterial;
            gameObject.GetComponent<Speed>().MovingSpeed *= paddleSlowingFactor;
            HasSlowPaddlePowerup = false;
        }
    }
}
