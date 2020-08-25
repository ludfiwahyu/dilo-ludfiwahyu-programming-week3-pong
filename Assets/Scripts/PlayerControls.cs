using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

	public KeyCode moveUp = KeyCode.W;
	public KeyCode moveDown = KeyCode.S;
	public float speed = 10.0f;
	public float yBoundary = 9f;
	private Rigidbody2D rigidBody2D;

	// Use this for initialization
	void Start()
	{
		rigidBody2D = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		Vector2 vel = rigidBody2D.velocity;
		if (Input.GetKey(moveUp))
		{
			vel.y = speed;
		}
		else if (Input.GetKey(moveDown))
		{
			vel.y = -speed;
		}
		else if (!Input.anyKey)
		{
			vel.y = 0;
		}
		rigidBody2D.velocity = vel;

		Vector3 pos = transform.position;
		if (pos.y > yBoundary)
		{
			pos.y = yBoundary;
		}
		else if (pos.y < -yBoundary)
		{
			pos.y = -yBoundary;
		}
		transform.position = pos;
	}
}