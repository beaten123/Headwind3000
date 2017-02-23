using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float acceleration;
    public float maxspeed;

    private Rigidbody rb;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }

	void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);

        rb.AddForce(movement * acceleration);

        rb.velocity = clampVector(rb.velocity, 0.0f, maxspeed);
	}

    public static Vector3 clampVector(Vector3 vec, float min, float max)
    {
        if (vec.magnitude < min && vec.magnitude != 0.0f) return (vec * min/vec.magnitude);
        else if (vec.magnitude > max) return (vec * max / vec.magnitude);
        else return vec * 1;
    }
}
