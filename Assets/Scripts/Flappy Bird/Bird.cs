using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [Header("Bird Attributes")]
    [SerializeField] float jumpForce;

    [SerializeField] float rotationUp, rotationDown;

    [SerializeField] float xSpeed;

    private Vector3 birdRotation;
    private Rigidbody2D myBody;

    public bool hasTheGameStarted, hasBirdDied, deathSoundPlayed;

    private Animator anim;

    private int score;

    [SerializeField] AudioClip deathClip, flyClip, scoreClip;

    

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        deathSoundPlayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasTheGameStarted && !hasBirdDied)
        {
            FixBirdRotation();
            XMoveMent();
            JumpMovement();
        }
        else
        {
            TapToMakeTheBirdJump();
        }

        if (hasBirdDied)
        {
            anim.speed = 0;
            if (!deathSoundPlayed)
            {
                AudioSource.PlayClipAtPoint(deathClip, transform.position);
                deathSoundPlayed = true;
            }
            
        }


    }

    private void TapToMakeTheBirdJump()
    {
        if (myBody.velocity.y < -1 && !hasBirdDied)
        {
            myBody.velocity = Vector2.up * jumpForce * .365f;
        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            hasTheGameStarted = true;
            if (!hasBirdDied)
            {
                myBody.velocity = Vector2.up * jumpForce;
            }
        }
    }

    void JumpMovement()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            myBody.velocity = Vector2.up * jumpForce;
            AudioSource.PlayClipAtPoint(flyClip, transform.position);
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

    void XMoveMent()
    {
        transform.position += new Vector3(Time.smoothDeltaTime * xSpeed, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Pipe")
        {
            hasBirdDied = true;
        }
        if (collision.tag == "PipeScore")
        {
            score++;

            SpeedUp();                      

            PlayerPrefs.SetInt("Score", score);
            AudioSource.PlayClipAtPoint(scoreClip, transform.position);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            hasBirdDied = true;
        }
    }

    void SpeedUp()
    {
        if (score % 5  == 0 && score > 0)
        {
            xSpeed += 0.1f;
        }
    }
}
