using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 7f;
    public float turnSpeed = 80f;
    float horizontalInput;
    float verticalInput;
    public float gravityModifier;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        // Moving the player forward
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * Time.smoothDeltaTime * turnSpeed * horizontalInput);

        // Rotating left and right
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.smoothDeltaTime * speed * verticalInput);
    }
}
