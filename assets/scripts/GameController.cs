using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	
	public GameObject Player;
	public GameObject GalaxyBackground;
	public GameObject TheCamera;
	
	public GameObject[] backgroundTiles;
	
	public int gridSize = 20;
	
	void Start () {
		
		Player = Resources.Load <GameObject>("Prefabs/PlayerPrefabs/Serenity");
		GameObject PlayerClone = (GameObject) Instantiate (Player);
		
        //GalaxyBackground = Resources.Load <GameObject> ("Prefabs/GalaxyBackground");
        //backgroundTiles = new GameObject[gridSize];
        //for (int i =0;i<backgroundTiles.Length;i++) {
        //    backgroundTiles[i] = (GameObject)Instantiate(GalaxyBackground);
        //    backgroundTiles[i].transform.position = PlayerClone.transform.position + new Vector3(100,100);
        //}
        //backgroundTiles [0].transform.position = new Vector3 (0, 0);
		
		TheCamera = (GameObject)Instantiate (Resources.Load<GameObject> ("Prefabs/MainCamera"));

		TheCamera.GetComponent<MainCamera>().target = PlayerClone.transform;
		//Camera.main.GetComponent<FollowTarget2D> ().target = PlayerClone.transform;
	}
	
	
	void Update () {
		
	}
}
