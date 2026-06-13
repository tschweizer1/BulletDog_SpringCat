using System;
using System.Collections;
using UnityEngine;

public class SpringCatJump : MonoBehaviour
{
    private PlayerState playerState;
    private bool abilityOnCooldown;
    private Rigidbody2D rigidBody;
    private void Awake()
    {
        playerState = GetComponent<PlayerState>();
        rigidBody = GetComponent<Rigidbody2D>();
        abilityOnCooldown = false;
    }

    public void OnAbility()
    {
        if (playerState.currentState() == global::playerState.Swapping || abilityOnCooldown)
        {
            return;
        }
        abilityOnCooldown = true;
        playerState.changeState(global::playerState.Ability);
        rigidBody.AddForce(Vector2.up * rigidBody.linearVelocityY * -1, ForceMode2D.Impulse);
        rigidBody.AddForce(Vector2.up * GameParameters.springJumpForce, ForceMode2D.Impulse);
        StartCoroutine(DashTime());
        StartCoroutine(Cooldown());
    }
    
    private IEnumerator DashTime()
    {
        yield return new  WaitForSeconds(GameParameters.springJumpForce * 0.01f);
        playerState.changeState(global::playerState.Jumping);
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(GameParameters.springJumpCooldown);
        abilityOnCooldown = false;
    }
}
