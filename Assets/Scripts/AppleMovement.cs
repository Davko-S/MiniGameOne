using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleMovement : MonoBehaviour
{
    private Vector3 startPos;
    private float rotationSpeed = 10;
    private float leftBound = -8;
    private float rightBound = 8;
    public float lifetime = 3;

    private Rigidbody appleRb;

    // Start is called before the first frame update
    void Start()
    {
        appleRb = GetComponent<Rigidbody>();
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

        //transform.Rotate(new Vector3(0, 30, 0) * rotationSpeed * Time.deltaTime);
        float xRange = Random.Range(-3.0f, 3.0f);
        float yRange = Random.Range(0, 0.5f);
        appleRb.AddForce(new Vector3(xRange, yRange, 0) * 5, ForceMode.Acceleration);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
