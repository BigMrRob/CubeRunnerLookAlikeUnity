using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;

    public float forwardForce = 100f;
    public float sidewaysForce = 500f;
    public float upwardsForce = 400f;

    // We use "Fixed" Update when we are changing physics
    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("space") && Math.Floor(rb.position.y) == 1)
        {
            rb.AddForce(0, upwardsForce * Time.deltaTime, 0);
        }

        if (rb.position.y <= -1)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
