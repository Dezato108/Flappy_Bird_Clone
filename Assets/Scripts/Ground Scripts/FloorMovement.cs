using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMovement : MonoBehaviour
{
    private Bird bird;

    [SerializeField] float xBound;


    private void Awake()
    {
        bird = GameObject.FindObjectOfType<Bird>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.x <= xBound)
        {
            transform.localPosition = new Vector3(0, transform.localPosition.y, transform.localPosition.z);
        }

        if (!bird.hasBirdDied)
        {
            transform.Translate(-Time.deltaTime, 0, 0);
        }

    }
}
