using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject pipes;

    [SerializeField] float timerMin, timerMax;
    [SerializeField] float yBoundMin, yBoundMax;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnPipe());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnPipe()
    {
        yield return new WaitForSeconds(Random.Range(timerMin, timerMax));

        Instantiate(pipes, new Vector2(transform.position.x, Random.Range(yBoundMin, yBoundMax)), Quaternion.identity);

        StartCoroutine(SpawnPipe());
    }
}
