using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles input and movement of a character
[ExecuteInEditMode]
public class CharacterController2D : MonoBehaviour 
{

	public float speed;
	public float rayLength;
	[Range(0.1f, 1.25f)]
	public float boundsize;
	[Range(2, 10)]
	public int raycount;
	private Rigidbody2D rb;
	private BoxCollider2D col;

	void Start () 
	{
		rb = GetComponent<Rigidbody2D>();
		col = GetComponent<BoxCollider2D>();
		Debug.Log(col.bounds.max);
	}
	
	void Update () 
	{
		Move();

		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, rayLength);

		float stepy = col.bounds.size.y / (raycount-1);
		for (float i = 0; i <= col.bounds.size.y; i += stepy)
		{
			RaycastHit2D currenthit = Physics2D.Raycast(transform.position + new Vector3(col.bounds.extents.x, col.bounds.extents.y - i), Vector3.right, rayLength);
			Debug.DrawRay(transform.position + new Vector3(col.bounds.extents.x, col.bounds.extents.y - i, 0) * boundsize, Vector3.right * rayLength, Color.red);
			if (currenthit.collider != null && currenthit.collider.tag != "Player")
				Debug.Log(currenthit.collider.gameObject.name);
		}
		float stepx = col.bounds.size.x / (raycount-1);
		for (float i = 0; i <= col.bounds.size.x; i += stepx)
		{
			Debug.DrawRay(transform.position - new Vector3(col.bounds.extents.x - i, col.bounds.extents.y, 0) * boundsize, Vector3.down * rayLength, Color.red);
		}
	}

	void FixedUpdate()
	{
		
	}

	void Move()
	{
		rb.MovePosition(rb.position + new Vector2(1, 0) * speed * Input.GetAxis("Horizontal") * Time.deltaTime);	
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireCube(transform.position, new Vector3(col.bounds.size.x * boundsize, col.bounds.size.y * boundsize, 0));
	}
}
