using System;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private PlayerState playerState;

    public void Awake()
    {
        playerState = GetComponent<PlayerState>();
    }

    public void OnJump()
    {
        if (playerState.currentState() != global::playerState.Grounded)
        {
            return;
        }
        playerState.changeState(global::playerState.Jumping);
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * GameParameters.jumpForce,  ForceMode2D.Impulse);
    }
}
