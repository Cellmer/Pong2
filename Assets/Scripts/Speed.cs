using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    [SerializeField]
    private float movingSpeed;
    public float MovingSpeed
    { 
        get { return movingSpeed; } 
        set { movingSpeed = value; } 
    }

    [SerializeField]
    private float rotateSpeed;
    public float RotateSpeed
    {
        get { return rotateSpeed; }
        set { rotateSpeed = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
