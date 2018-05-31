using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{

	public GameObject bulletPrefab;
	public GameObject cannonPivot;
	public Transform bulletSpawn;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		MoveCannon();
		if (Input.GetMouseButtonDown(0))
		{
			Shoot();
		}
	}

	void Shoot () 
	{
		// calculate mouse position as world position
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Math.Abs(Camera.main.transform.position.z)));

		// calculate direction of mouse from bullet spawn position
		Vector3 shootdirection = mousePosition - this.bulletSpawn.position;
		Debug.DrawRay(bulletSpawn.position, shootdirection, new Color(1, 0.675f, 0, 1), 1.25f);
		Vector3 dirNormalized = Vector3.Normalize(shootdirection);

		// instantiate bullet prefab
		GameObject go = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);

		// rotate bullet prefab to point towards where we shot
		float rotangle = Vector2.SignedAngle(Vector2.right, new Vector2(dirNormalized.x, dirNormalized.y));
		go.GetComponent<BasicBullet>().SetVelocity(go.transform.right);
		go.transform.Rotate(0, 0, rotangle);
	}

	void MoveCannon()
	{
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Math.Abs(Camera.main.transform.position.z)));
		Vector3 shootdirection = mousePosition - cannonPivot.transform.position;
		Debug.DrawRay(cannonPivot.transform.position, shootdirection, Color.blue);
		shootdirection.Normalize();
		float rotangle = Vector2.SignedAngle(Vector2.right, new Vector2(shootdirection.x, shootdirection.y));
		// cannonPivot.transform.LookAt(mousePosition, Vector3.up);
		cannonPivot.transform.eulerAngles = new Vector3(0, 0, rotangle - 90);
	}

}
