using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerControls : MonoBehaviour
{

	public KeyCode moveUp = KeyCode.W;
	public KeyCode moveDown = KeyCode.S;
	public float speed = 10.0f;
	public float yBoundary = 9.0f;
	private Rigidbody2D rigidBody2D;
	private int score;

	private ContactPoint2D lastContactPoint;

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

	public void IncrementScore()
	{
		score++;
	}

	public void ResetScore()
	{
		score = 0;
	}

	public int Score
	{
		get { return score; }
	}

	public ContactPoint2D LastContactPoint
    {
		get { return lastContactPoint; }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
         if (collision.gameObject.name == "Ball")
        {
			lastContactPoint = collision.GetContact(0);
        }
    }

}