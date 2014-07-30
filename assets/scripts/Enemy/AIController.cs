using UnityEngine;
using System.Collections;

public class AIController : MonoBehaviour 
{
    GameObject[] enemies;

	// Use this for initialization
	void Start () 
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
	}
	
	// Update is called once per frame
	void Update () 
    {
	    
	}
}
