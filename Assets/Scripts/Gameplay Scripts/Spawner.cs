using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Bird bird;

    [SerializeField] GameObject pipes;

    [SerializeField] float timerMin, timerMax;
    [SerializeField] float yBoundMin, yBoundMax;

    private bool startSpawning;

    private void Awake()
    {
        bird = GameObject.FindObjectOfType<Bird>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(SpawnPipe());
    }

    // Update is called once per frame
    void Update()
    {
        if (bird.hasTheGameStarted && !startSpawning)
        {
            StartCoroutine(SpawnPipe());
            startSpawning = true;
        }

        if (bird.hasBirdDied)
        {
            StopAllCoroutines();
        }
    }

    IEnumerator SpawnPipe()
    {
        yield return new WaitForSeconds(2f);

        Instantiate(pipes, new Vector2(transform.position.x, Random.Range(yBoundMin, yBoundMax)), Quaternion.identity);

        StartCoroutine(SpawnPipe());
    }
}
