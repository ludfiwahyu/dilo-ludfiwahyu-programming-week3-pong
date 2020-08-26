using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SideWall : MonoBehaviour
{
    public PlayerControls player;
    [SerializeField] private GameManager gameManager;

    void  OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.name == "Ball")
        {
            player.IncrementScore();

            // Jika skor pemain belum mencapai skor maksimal...
            if (player.Score < gameManager.maxScore)
            {
                // restart game setelah bola mengenai dinding.
                hitInfo.gameObject.SendMessage("RestartGame", 2.0f, SendMessageOptions.RequireReceiver);
            }
        }
    }
}
