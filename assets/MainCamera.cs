using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {
	
	public Transform target;
	
	public float radiusScale = 0.15f;
	public float durationScale = 0.2f;
	
	float radius;
	float duration;
	
	float timer;
	bool shaking;
	
	// Use this for initialization
	void Start () {
		
		shaking = false;
		timer = 0;
	}
	
	
	public void Shake(float intensity, float distance)
	{
		float distanceSquared = Mathf.Max (1.0f, distance * distance);
		radius = radiusScale * intensity / distanceSquared;
		duration = durationScale * intensity / distanceSquared;
		timer = 0;
		shaking = true;
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void FixedUpdate()
	{
		if (transform == null)
			return;

		if (!shaking) 
		{
			transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
			return;
		}
		
		timer += Time.fixedDeltaTime;
		
		if (timer >= duration) 
		{
			shaking = false;
			return;
		}
		
		Vector3 shake = Random.insideUnitCircle * radius;
		gameObject.transform.position = 
			new Vector3(target.position.x, target.position.y, transform.position.z) + shake; 
		
	}
}
