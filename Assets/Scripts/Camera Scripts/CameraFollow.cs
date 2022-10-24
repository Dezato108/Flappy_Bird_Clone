using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform bird;

    [SerializeField] float offSetX = 0.5f;

    private void Awake()
    {
        bird = FindObjectOfType<Bird>().transform;

        //below is another way to find gameobject
        //bird = GameObject.Find("Flappy Bird").transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(bird.position.x + offSetX, 0, transform.position.z);
    }
}
