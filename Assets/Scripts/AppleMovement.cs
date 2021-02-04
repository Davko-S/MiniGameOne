using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleMovement : MonoBehaviour
{
    private Vector3 startPos;
    private float leftBound = -5;
    private float rightBound = 5;
    public float lifetime = 3;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        // Invisble wall on the right side
        if (transform.position.x > rightBound)
        {
            transform.position = new Vector3(rightBound, transform.position.y, transform.position.z);
        }
        // Invisible wall on the left side
        if (transform.position.x < leftBound)
        {
            transform.position = new Vector3(leftBound, transform.position.y, transform.position.z);
        }
    }
}
