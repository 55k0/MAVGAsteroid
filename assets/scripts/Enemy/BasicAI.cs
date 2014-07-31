using UnityEngine;
using System.Collections;

public class BasicAI : MonoBehaviour 
{
    GameObject target = null;

    public float forwardSpeed = 5.0f;
    public float sidewaysSpeed = 4.0f;
    public float stopDistance = 8.0f;
    public float attackDistance = 12.0f;

    public float fireRate = 1.5f;
    public float positionOffset = 1.5f;
    public float bulletSpeed = 10.0f;

    float fireTimer;

	// Use this for initialization
	void Start () 
    {
        fireTimer = 0.0f;
		target = GameObject.FindGameObjectWithTag("Player");

	}

    IEnumerator GetReference()
    {
        yield return new WaitForFixedUpdate();

    }
	
	// Update is called once per frame
	void Update () 
    {
        fireTimer += Time.deltaTime;

		if (target == null)
			return;

		else
			LookAt(target.transform.position); 
	}

    void FixedUpdate()
    {
		if (target == null)
			return;

        if (target.rigidbody2D.velocity.x < forwardSpeed && target.rigidbody2D.velocity.y < forwardSpeed && Vector2.Distance(transform.position, target.transform.position) < stopDistance)
        {
            Circle(target.transform.position);
        }
        else
        {
            MoveTowards(target.transform.position);
        }
    }

    Vector3 targetPosition;

    void LookAt(Vector3 Position)
    {
        var dir = Position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle -90, Vector3.forward);
    }

    void MoveTowards(Vector3 Position)
    {
        if (Vector2.Distance(transform.position, target.transform.position) > stopDistance)
        {
            rigidbody2D.AddRelativeForce(new Vector2(0, forwardSpeed), ForceMode2D.Force);
        }

        if (Vector2.Distance(transform.position, target.transform.position) < stopDistance && rigidbody2D.velocity.x <= 1 || rigidbody2D.velocity.y <= 1)
        {
            rigidbody2D.drag = 0.5f;
        }

        if (fireTimer > fireRate && Vector2.Distance(transform.position, target.transform.position) < attackDistance)
        {
            Shoot();
        }
    }

    void Circle(Vector3 Position)
    {
        rigidbody2D.AddRelativeForce(new Vector2(0, forwardSpeed - 3.5f), ForceMode2D.Force);
        rigidbody2D.AddRelativeForce(new Vector2(sidewaysSpeed, 0), ForceMode2D.Force);

        if(fireTimer > fireRate)
        {
            Shoot();
        }
    }

    void Shoot()
    {
<<<<<<< HEAD
        GameObject bullet = (GameObject)Instantiate(Resources.Load("Laser"),
=======
        GameObject bullet = (GameObject)Instantiate(Resources.Load("Bullet"),
>>>>>>> origin/master
                                                          transform.position + transform.up * positionOffset,
                                                          transform.rotation);

        bullet.rigidbody2D.velocity = bulletSpeed * transform.up;
        bullet.rigidbody2D.drag = 0.0f;

        fireTimer = 0.0f;
    }
}

