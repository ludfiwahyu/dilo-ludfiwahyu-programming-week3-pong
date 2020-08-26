using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //Player 1
    public PlayerControls player1; //dari playercontrol.cs
    private Rigidbody2D player1RigidBody;

    //Player 2
    public PlayerControls player2; //dari playercontrol.cs
    private Rigidbody2D player2RigidBody;

    //Ball
    public BallControl ball; //dari ballcontrol.cs
    private Rigidbody2D ballRigidBody;
    private CircleCollider2D ballCollider;

    //maxScore
    public int maxScore;

    void Start()
    {
        player1RigidBody = player1.GetComponent<Rigidbody2D>();
        player2RigidBody = player2.GetComponent<Rigidbody2D>();
        ballRigidBody = ball.GetComponent<Rigidbody2D>();
        ballCollider = ball.GetComponent<CircleCollider2D>();
    }

    
    void OnGUI()
    {
        //// score UI location
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + player1.Score);
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + player1.Score);

        //// Restart Game Button 
        if (GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53), "RESTART"))
        {
            player1.ResetScore();
            player2.ResetScore();

            ball.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
        }

        //// Jika player 1 win
        if (player1.Score == maxScore)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 10, 2000, 1000), "Player 1 WINS");
            ball.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
        }

        //// Jika player 2 win
        else if (player2.Score == maxScore)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 10, 2000, 1000), "Player 2 WINS");
            ball.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
        }


    }
}
