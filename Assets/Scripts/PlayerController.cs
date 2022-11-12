using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	Animator animator;
	Rigidbody2D rigidbody;

	float walkSpeed = 2;	// sigh, ffs, I left this at zero D:
	float attaccSpeed;

	const int STATE_IDLE = 0;
	const int STATE_WALKING = 1;

	// Character always starts facing right, and is in the IDLE state (0)
	// Also, an underscore that prefixes a variable name makes it private. It's not a naming convention, it is syntax
	string _currentDirection = "right";
	int _currentState = 0;

	// Use this for initialization
	void Start () {
		// Getting Animator component that we need to add later...
		// TODO
		animator = this.GetComponent<Animator>();
		rigidbody =  this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Even this method is called once per frame just like the one above but everyone says this is good for physics related 
	// stuff so ¯\_(ツ)_/¯
	void FixedUpdate() {
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)) {
			// If we receive input corresponding to any of the above keys then...
			if (Input.GetKey(KeyCode.A)) {
				this.transform.Translate(Vector3.right * walkSpeed * Time.deltaTime);
				ChangeDirection("left");
			} else if (Input.GetKey(KeyCode.D)) {
				this.transform.Translate(Vector3.right * walkSpeed * Time.deltaTime);
				ChangeDirection("right");
			}
		} else {
			// Always return to the idle state when there is no keyboard input
			ChangeState(0);
		}
	}

	void ChangeState(int state) {
		if (state == _currentState)
			return;
		
		switch (state) {
			case STATE_IDLE: animator.SetInteger("parameter", STATE_IDLE);
							 break;
			case STATE_WALKING: animator.SetInteger("parameter", STATE_WALKING);
								break;
		}

		_currentState = state;

		// Bob the builder, yes we can! hurray
	}

	// To change direction of sprite to either face left or right. We will rotate the sprite accordingly
	void ChangeDirection(string direction) {
		// To think that == works for comparing strings in C# but not in Java >:(
		if (_currentDirection != direction)  {
			if (direction == "right") {
				this.transform.Rotate(0, 180, 0);
				_currentDirection = "right";
			} else if (direction == "left"){
				this.transform.Rotate(0, -180, 0);
				_currentDirection = "left";
			}
		}
	}
}
