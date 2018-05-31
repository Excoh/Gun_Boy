using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles input and movement of a character
[ExecuteInEditMode]
public class CharacterController2D : MonoBehaviour 
{

	public LayerMask collisionMask;

	public float jumpheight;
	public float speed;
	public Vector2 velocity;
	public Vector2 acceleration;
	public float gravity;
	public float rayLength;
	[Range(0.1f, 1)]
	public float boundsize;
	[Range(2, 10)]
	public int raycount;
	private Rigidbody2D rb;
	private float currentRayDistance = 2;
	private BoxCollider2D col;

	void Start () 
	{
		rb = GetComponent<Rigidbody2D>();
		col = GetComponent<BoxCollider2D>();

        if (raycount <= 1) raycount = 2;
	}
	
	void Update () 
	{
		Move();
		Jump();

		float stepy = col.bounds.size.y / (raycount-1);
		float stepx = col.bounds.size.x / (raycount-1);
        for (int i = 0; i < raycount; i++)
        {
            Debug.DrawRay(transform.position + new Vector3(col.bounds.extents.x, col.bounds.extents.y - (i * stepy), 0) * boundsize, Vector3.right * rayLength, Color.red);
			Debug.DrawRay(transform.position - new Vector3(col.bounds.extents.x - (i * stepx), col.bounds.extents.y, 0) * boundsize, Vector3.down * rayLength, Color.red);
        }
	}

	void FixedUpdate()
	{
	}

	void Move()
	{
		velocity = (Vector2.right * Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime);
		Debug.DrawRay(transform.position, Vector3.right * currentRayDistance, Color.red);
		RaycastHit2D info = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.right, currentRayDistance, collisionMask);
		if (info.transform != null)
		{
			currentRayDistance = info.distance;
			if (currentRayDistance - col.bounds.extents.x < 0.05)
			{
				velocity = -velocity;
			}
			Debug.Log(info.transform.gameObject.name);
		}
		else
		{
			currentRayDistance = 2;
		}
		transform.Translate(velocity); 	
	}
 	void Jump()
	{
		transform.Translate(Vector3.up * Input.GetAxisRaw("Vertical") * jumpheight * Time.deltaTime);
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireCube(transform.position, new Vector3(col.bounds.size.x * boundsize, col.bounds.size.y * boundsize, 0));
	}

}
