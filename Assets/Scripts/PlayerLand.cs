using System;
using UnityEngine;

public class PlayerLand : MonoBehaviour
{
    private PlayerState playerState;

    private void Awake()
    {
        playerState = GetComponent<PlayerState>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            playerState.changeState(global::playerState.Grounded);
        }
    }
}
