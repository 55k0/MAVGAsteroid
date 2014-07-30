using UnityEngine;
using System.Collections;

public class HomingMissle : MonoBehaviour {

	GameObject target;
	Rigidbody2D body;


	public float angularVelocity = 50.31f;

	// Use this for initialization
	void Start () {
		target = null;
		body = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

				GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");


				float targetDistance = 1000;


				foreach (GameObject enemy in enemies) {
						float distance = Vector2.Distance (enemy.transform.position, gameObject.transform.position);

						if (distance < targetDistance) {
								target = enemy;
								targetDistance = distance;

						}
				}

				if (target != null) {
						Vector2 v = target.transform.position - gameObject.transform.position;
			
						Vector2 vPerp = new Vector2 (v.y, -v.x);
						float a = Vector2.Dot (gameObject.transform.up, vPerp);
						//float newRotation;

						if (Mathf.Abs (a) < 0.1) {
								gameObject.rigidbody2D.angularVelocity = 0;
						} else if (a < 0.0f) { 
								//	newRotation = gameObject.rigidbody2D.rotation + gameObject.rigidbody2D.angularVelocity * Time.fixedDeltaTime;
								//	a = Vector2.Dot(new Vector2(-Mathf.Sin(newRotation), Mathf.Cos(newRotation)), vPerp);
								//	if ( a > 0.0f )
								//		gameObject.rigidbody2D.rotation = ( Mathf.Atan2(v.y, v.x) + 0.5f * Mathf.PI );

								//	else 
								gameObject.rigidbody2D.AddTorque (-angularVelocity);
						} else {
								//	newRotation = gameObject.rigidbody2D.rotation - gameObject.rigidbody2D.angularVelocity * Time.fixedDeltaTime;
								//	a = Vector2.Dot(new Vector2(-Mathf.Sin(newRotation), Mathf.Cos(newRotation)), vPerp);
								//	if ( a < 0.0f )
								//		gameObject.rigidbody2D.rotation = ( Mathf.Atan2(v.y, v.x) + 0.5f * Mathf.PI );
								//	else 
								gameObject.rigidbody2D.AddTorque (angularVelocity);
				
						}
				}




		float speed = gameObject.rigidbody2D.velocity.magnitude;
		gameObject.rigidbody2D.velocity = gameObject.transform.up * speed;
	}
}
