using UnityEngine;
using System.Collections;

public class DestroysWhenAnimationFinished : MonoBehaviour {
	// Use this for initialization
	void Start () {

		Destroy (gameObject, gameObject.GetComponent<Animator>().animation.clip.length);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
