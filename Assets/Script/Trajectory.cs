using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{

    // Skrip, collider, dan rigidbody bola
    public BallControl ball;
    CircleCollider2D ballCollider;
    Rigidbody2D ballRigidbody;

    // Bola "bayangan" yang akan ditampilkan di titik tumbukan
    public GameObject ballAtCollision;


    void Start()
    {
        ballRigidbody = ball.GetComponent<Rigidbody2D>();
        ballCollider = ball.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        bool drawBallAtCollision = false;
        Vector2 offsetHitPoint = new Vector2();
        RaycastHit2D[] circleCastHit2DArray =
        Physics2D.CircleCastAll(ballRigidbody.position, ballCollider.radius, ballRigidbody.velocity.normalized);

    }

   
}
