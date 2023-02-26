using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float verticalInput;
    private float speed = 4.0f;
    private float topBound = 6.0f;
    private float bottomBound = -6.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * Time.deltaTime * speed * verticalInput);

        // boundaries
        if(transform.position.y > topBound)
        {
            transform.position = new Vector3(-12, topBound, 0);
        }

        if (transform.position.y < bottomBound)
        {
            transform.position = new Vector3(-12, bottomBound, 0);
        }
    }
}
