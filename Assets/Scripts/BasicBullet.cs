using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : Projectile 
{
	public float life;		// how long this bullet lasts
	private Vector2 velocity;

	// Use this for initialization
	void Start () 
	{
		Destroy(this.gameObject, life);	
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.transform.Translate(velocity * speed * Time.deltaTime);
	}

	public void SetVelocity(Vector2 velocity)
	{
		this.velocity = velocity;
	}
	public void SetVelocity(float x, float y)
	{
		this.velocity = new Vector2(x, y);
	}

}
