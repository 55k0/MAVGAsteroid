using UnityEngine;
using System.Collections;

public class TakesDamage : MonoBehaviour {

	public int health = 3;
	public int damagedThreshold = 1;

	public Sprite sprite;
	public Sprite damagedSprite;

	SpriteRenderer spriteRenderer;

	bool dead;

	// Use this for initialization
	void Start () {
		dead = false;
		spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
		spriteRenderer.sprite = sprite;
	}


	void OnCollisionEnter2D (Collision2D col)
	{
<<<<<<< HEAD
		if (col.gameObject.name.Contains ("Laser") || col.gameObject.name.Contains ("HomingMissle")) 
=======
		if (col.gameObject.name.Contains ("Bullet") || col.gameObject.name.Contains ("HomingMissle")) 
>>>>>>> origin/master
		{


			health -= 1;
			if(health <= 0)
				dead = true;

			if(health <= damagedThreshold)
				spriteRenderer.sprite = damagedSprite;

			// get the average of the contact points.
			Vector2 pos = new Vector2(0, 0);
			foreach(ContactPoint2D p in col.contacts)
			{
				pos += p.point;
			}
			pos /= col.contacts.Length;


			GameObject cameraObj = GameObject.FindGameObjectWithTag ("MainCamera");
			GameObject playerObj = GameObject.FindGameObjectWithTag ("Player");

			float distance = 
				(new Vector2(playerObj.transform.position.x, playerObj.transform.position.y) - pos).magnitude;

			cameraObj.GetComponent<MainCamera>().Shake (2, distance);

			Instantiate (Resources.Load ("Explosion"), pos, transform.rotation);
		}
	}

	void LateUpdate()
	{
		if(dead)
			Destroy (gameObject);
	}

}
