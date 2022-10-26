using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PipeScore")
        {
            Destroy(collision.gameObject);
        }
    }
}
