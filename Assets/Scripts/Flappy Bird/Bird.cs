using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private Rigidbody2D myBody;

    public float jumpForce;

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
        JumpMovement();        
    }

    void JumpMovement()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            myBody.velocity = Vector2.up * jumpForce;
        }
    }
}
