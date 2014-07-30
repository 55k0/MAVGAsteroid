using UnityEngine;
using System.Collections;

public class DestroysOnCollision : MonoBehaviour {

	bool dead;

	// Use this for initialization
	void Start () {
		dead = false;
	}


	void OnCollisionEnter2D(Collision2D col)
	{

		dead = true;
	}

	void Update()
	{
		if (dead)
			Destroy (gameObject);
	}
}
