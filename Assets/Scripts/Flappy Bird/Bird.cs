using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [Header("Bird Attributes")]
    [SerializeField] float jumpForce;

    [SerializeField] float rotationUp, rotationDown;

    private Vector3 birdRotation;
    private Rigidbody2D myBody;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();    
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        FixBirdRotation();
        JumpMovement();        
    }

    void JumpMovement()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            myBody.velocity = Vector2.up * jumpForce;
        }
    }

    void FixBirdRotation()
    {
        float degreesToAdd = 0;
        if (myBody.velocity.y <= 0)
        {
            degreesToAdd = rotationDown;
        }
        
        if (myBody.velocity.y > 0)
        {
            degreesToAdd = rotationUp;
        }

        birdRotation = new Vector3(0, 0, Mathf.Clamp(birdRotation.z + degreesToAdd, -60, 30));

        transform.eulerAngles = birdRotation;
    }
}
