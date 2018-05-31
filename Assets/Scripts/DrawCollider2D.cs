using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class DrawCollider2D : MonoBehaviour 
{
	Collider2D[] colliders;
	// Use this for initialization
	void Start () 
	{
		colliders = GetComponents<Collider2D>();
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		foreach (Collider2D col in colliders)
		{
			if (col.GetType().Equals(typeof(BoxCollider2D)))
			{
				Gizmos.DrawWireCube(col.transform.position + new Vector3(col.offset.x, col.offset.y), col.bounds.size);
			}
			else if (col.GetType().Equals(typeof(CircleCollider2D)))
			{
				CircleCollider2D temp = (CircleCollider2D)col;
				Gizmos.DrawWireSphere(col.transform.position, temp.radius);
			}
		}
	}

}
