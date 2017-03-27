using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour {

	//the speed which we pretend the car is going at; related to speed at which walls/floor move
	public float simulatedSpeed;

	//how the player moves laterally
    public float acceleration;
    public float maxspeed;

	//pointer for rotating car model
	[SerializeField]
	private GameObject model;

    private Rigidbody rb;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }

	private void Update() {
		const float radianstodegrees = 180f/(float)Math.PI;

		Vector3 modelrot = new Vector3((float)Math.Atan(rb.velocity.y / simulatedSpeed)*radianstodegrees, (float)Math.Atan(rb.velocity.x / simulatedSpeed)*radianstodegrees, 0.0f);
		model.transform.localEulerAngles = modelrot;
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
