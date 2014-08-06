using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{

    public float playerHorizontalSpeed = 1000;
    public float playerVerticalSpeed = 0.040f;
	//public float playerSpeed = 4.0f;
	public float maxDistance = 50;
	private DistanceJoint2D orbitJoint = null; 
	public float minDistanceToTarget = .5f;

	void Start () 
    {
		orbitJoint = this.GetComponent<DistanceJoint2D>();
		orbitJoint.connectedAnchor = new Vector2(this.transform.position.x, this.transform.position.y);
	}

	void FixedUpdate () 
    {

		if(Input.GetButton("Up")) {

			//rigidbody2D.AddForce(Vector2.up * playerSpeed);
			orbitJoint.distance += playerVerticalSpeed * Time.deltaTime;

		}else if(Input.GetButton("Down")) {

			//rigidbody2D.AddForce(Vector2.up * playerSpeed * -1);

			if(orbitJoint.distance > minDistanceToTarget) {

			orbitJoint.distance -= playerVerticalSpeed * Time.deltaTime;

			}

		}

		if(Input.GetButton("Left")) {

			rigidbody2D.AddRelativeForce(Vector2.right * playerHorizontalSpeed * -1 * Time.deltaTime);

		}else if(Input.GetButton("Right")) {

			rigidbody2D.AddRelativeForce(Vector2.right * playerHorizontalSpeed * Time.deltaTime);

		}

		if(Input.GetButton("ChangeTarget")) {

			targetClosestEnemy();

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

		if(orbitJoint.connectedBody == null) {

			targetClosestEnemy();

		}

		/*

        mousePosition = Input.mousePosition;
		mousePosition = Camera.main.ScreenToWorldPoint (mousePosition);

        Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);
        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);

		*/

		//Debug.Log(Input.mousePosition.ToString());

		//mousePosition = new Vector3(orbitJoint.connectedBody.position.x, orbitJoint.connectedBody.position.y);
		//mousePosition = Camera.main.ScreenToWorldPoint (mousePosition);


		Transform targetTransform = orbitJoint.connectedBody.transform;

		Vector3 vectorToTarget = targetTransform.position - transform.position;
		float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
		Quaternion q = Quaternion.AngleAxis((angle - 90), Vector3.forward);
		transform.rotation = Quaternion.Slerp(transform.rotation, q, float.MaxValue);

		//Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);
		//transform.LookAt(orbitJoint.connectedBody.transform, Vector3.right);
		//transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);

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

	GameObject closestEnemy() {

		object[] objects = GameObject.FindGameObjectsWithTag("Enemy");

		GameObject closestObject = null;
		float closestDistance = float.MaxValue;

		foreach (GameObject obj in objects) {

			float distance = (obj.transform.position - this.transform.position).magnitude;

			if(distance < closestDistance)
			{

				closestObject = obj;
				closestDistance = distance;

			}
		}

		return closestObject;

	}

	void targetClosestEnemy() {

		orbitJoint.distance = (closestEnemy().transform.position - this.transform.position).magnitude;
		orbitJoint.connectedBody = closestEnemy().rigidbody2D;
		orbitJoint.connectedAnchor = new Vector2(0, 0);

	}

}
