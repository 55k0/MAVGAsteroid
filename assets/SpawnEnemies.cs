using UnityEngine;
using System.Collections;

public class SpawnEnemies : MonoBehaviour {
	
	public bool spawnEnemies = true;
	public float spawnRate = 5.0f;
	public float cutOffNear = 2.0f;
	public float spawnRadius = 7.0f;
	
	float spawnTimer;
	
	// Use this for initialization
	void Start () {
		spawnTimer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
		spawnTimer += Time.deltaTime;

        Spawn();
	}

    void Spawn()
    {

        if (spawnTimer >= spawnRate)
        {
            spawnTimer -= spawnRate;

			if(spawnEnemies) {

            Vector2 pos = (Random.insideUnitCircle * Random.Range(cutOffNear, spawnRadius)) + gameObject.rigidbody2D.position;

            Instantiate(Resources.Load("Enemy"), pos, Quaternion.identity);

			}

        }
    }

}