using UnityEngine;
using System.Collections;

public class background : MonoBehaviour {

	GameObject GameCon;

	void Start () {
		GameCon = GameObject.FindGameObjectWithTag ("GameController");
	}
	

	void Update () {
	
	}
	/*
	void OnTriggerEnter2D(Collider2D  col){

	}

	void OnTriggerExit2D(Collider2D col){

	}
	*/
}
