using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

	public float fireRate = 1.5f;
	public float positionOffset = 1.0f;
	public float bulletSpeed = 10.0f;

	float fireTimer;

	// Use this for initialization
	void Start () {
		fireTimer = 0.0f;
	}
	

	void Update () {

		fireTimer += Time.deltaTime;

		if (Input.GetKey (KeyCode.Space) && fireTimer > fireRate) 
		{
<<<<<<< HEAD
			GameObject bullet = (GameObject) Instantiate (Resources.Load ("Laser"), 
=======
			GameObject bullet = (GameObject) Instantiate (Resources.Load ("Bullet"), 
>>>>>>> origin/master
			                                              transform.position + transform.up * positionOffset, 
			                                              transform.rotation);		

			bullet.rigidbody2D.velocity = bulletSpeed * transform.up;
			bullet.rigidbody2D.drag = 0.0f;

			fireTimer = 0.0f;
		
		}
	}
}
