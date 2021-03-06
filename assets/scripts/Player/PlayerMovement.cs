﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{

    //public float playerHorizontalSpeed = 4.0f;
    //public float playerVerticalSpeed = 4.0f;
	public float playerSpeed = 4.0f;
	public float maxDistance = 50;
	
	void Start () 
    {

	}
	

	void FixedUpdate () 
    {

		if(Input.GetButton("Up")) {

			rigidbody2D.AddForce(Vector2.up * playerSpeed);

		}else if(Input.GetButton("Down")) {

			rigidbody2D.AddForce(Vector2.up * playerSpeed * -1);

		}

		if(Input.GetButton("Left")) {

			rigidbody2D.AddForce(Vector2.right * playerSpeed * -1);

		}else if(Input.GetButton("Right")) {

			rigidbody2D.AddForce(Vector2.right * playerSpeed);

		}

		/*

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

        if (Input.GetButton("Horizontal"))
        {
            rigidbody2D.AddRelativeForce(new Vector2(moveHorizontal * playerHorizontalSpeed, 0), ForceMode2D.Force);
        }
        if (Input.GetButton("Vertical"))
        {
            rigidbody2D.AddRelativeForce(new Vector2(0, moveVertical * playerVerticalSpeed), ForceMode2D.Force);
        }
		if (Input.GetButton("Fire2")){
			rigidbody2D.AddForce(new Vector2((rigidbody2D.velocity.x)/-0.25f,(rigidbody2D.velocity.y)/-0.25f));
		}

		*/

    }

    Vector3 mousePosition;

    void Update()
    {
        mousePosition = Input.mousePosition;
		mousePosition = Camera.main.ScreenToWorldPoint (mousePosition);

        Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);
        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);


		destroyObjects();

    }

	void destroyObjects() {

		object[] objects = GameObject.FindObjectsOfType(typeof (GameObject));

		foreach (GameObject obj in objects) {
			if((obj.transform.position - this.transform.position).magnitude > maxDistance)
			{
				Destroy (obj);
			}
		}

	}

}
