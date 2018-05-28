using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class DrawColliders : MonoBehaviour 
{
	Collider2D[] colliders;

	void Start()
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
				Gizmos.DrawWireCube(transform.position, col.bounds.size);
			}
			else if (col.GetType().Equals(typeof(CircleCollider2D)))
			{
				CircleCollider2D temp = (CircleCollider2D)col;
				Gizmos.DrawWireSphere(transform.position, temp.radius);
			}
		}
	}
}
