using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBack : MonoBehaviour
{
    public float speed = 0f;
    private float drivingDistance = 58f;
    private float startingPos;

    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.smoothDeltaTime * speed);
        if (transform.position.z < startingPos - drivingDistance || transform.position.y < -2)
        {
            Destroy(gameObject);
        }
    }
}
