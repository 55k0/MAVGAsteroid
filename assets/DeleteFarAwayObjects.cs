using UnityEngine;
using System.Collections;

public class DeleteFarAwayObjects : MonoBehaviour {

	public GameObject player;
	public float maxDistance = 50;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		object[] objects = GameObject.FindObjectsOfType(typeof (GameObject));

		foreach (GameObject obj in objects) {
			if((obj.transform.position - player.transform.position).magnitude > maxDistance)
			{
				Destroy (obj);
			}
		}
	}
}
