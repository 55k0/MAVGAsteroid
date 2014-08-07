using UnityEngine;
using System.Collections;
using System;

public class TakesDamage : MonoBehaviour {
	
	public int health = 3;
	public int damagedThreshold = 1;
	public int maxShields = 5;
	public float shields = 5;
	public float shieldDelay = 1.0f;
	public float shieldRegen = 0.1f;
	private DateTime lastHit = DateTime.Now;
	
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
	
	void FixedUpdate(){
		
		if(shields < maxShields) {
			
			if((DateTime.Now.Subtract(lastHit).Seconds > shieldDelay)) {
				
				shields += shieldRegen;
				
			}
			
		}else if(shields > maxShields) {
			
			shields = maxShields;
			
		}
		
	}
	
	void OnCollisionEnter2D (Collision2D col)
	{
		if (isBullet(col)) 
		{
			
			lastHit = DateTime.Now;
			
			if(shields >= 1) {
				
				shields -= 1;
				
			}else {
				
				health -= 1;
				
			}
			
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
	
	bool isBullet(Collision2D col) {
		
		string[] bulletNames = new string[]{"Laser","HomingMissle"};
		
		for(int i=0;i<bulletNames.Length;i++) {
			
			if(col.gameObject.name.Contains(bulletNames[i])) {
				
				return true;
				
			}
			
		}
		
		return false;
		
	}
	
}