using UnityEngine;
using System.Collections;

public class SortingLayerAndOrder : MonoBehaviour {


	public string sortingLayerName = "Default";
	public int sortingOrder = 0;
	

	// Use this for initialization
	void Start () {
		renderer.sortingLayerName = sortingLayerName;
		renderer.sortingOrder     = sortingOrder;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
