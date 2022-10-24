using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMovement : MonoBehaviour
{
    [SerializeField] float xBound;

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.x <= xBound)
        {
            transform.localPosition = new Vector3(0, transform.localPosition.y, transform.localPosition.z);
        }

        transform.Translate(-Time.deltaTime, 0, 0);
    }
}
