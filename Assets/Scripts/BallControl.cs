using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    public float xInitialForce;
    public float yInitialForce;

    private Vector2 trajectoryOrigin;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        RestartGame();
        trajectoryOrigin = transform.position;
    }

    void ResetBall()
    {
        rigidBody2D.position = Vector2.zero;
        transform.position = Vector2.zero;
    }
    void PushBall()
    {
        float yRandomInitialForce = Random.Range(-yInitialForce, yInitialForce);

        float randomDirection = Random.Range(0, 2);
        if (randomDirection < 1.0f)
        {
            rigidBody2D.AddForce(new Vector2(-xInitialForce, yRandomInitialForce));
        }
        else
        {
            rigidBody2D.AddForce(new Vector2(xInitialForce, yRandomInitialForce));
        }

    }

    void RestartGame()
    {
        ResetBall();
        Invoke("PushBall", 2);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        trajectoryOrigin = transform.position;
    }

    public Vector2 TrajectoryOrigin
    {
        get { return trajectoryOrigin; }
    }
    
    //void OnCollisionEnter2D(Collision2D coll)
    //{
    //    if (coll.collider.CompareTag("Player"))
    //    {
    //        Vector2 vel;
    //        vel.x = rigidBody2D.velocity.x;
    //        vel.y = (rigidBody2D.velocity.y / 2.0f) + (coll.collider.attachedRigidbody.velocity.y / 3.0f);

    //    }
    //}

}
