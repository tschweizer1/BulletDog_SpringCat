using System;
using System.Collections;
using UnityEngine;

public class BulletDogDash : MonoBehaviour
{
    private PlayerFacingDirection direction;
    private PlayerState playerState;
    private Rigidbody2D rigidBody;
    private bool abilityOnCooldown;

    private void Awake()
    {
        playerState = GetComponent<PlayerState>();
        rigidBody =  GetComponent<Rigidbody2D>();
        direction = GetComponent<PlayerFacingDirection>();
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
        rigidBody.AddForce(rigidBody.linearVelocity * -1, ForceMode2D.Impulse);
        rigidBody.gravityScale = 0;
        if (direction.isFacingRight)
        {
            rigidBody.AddForce(Vector2.right * GameParameters.dashForce, ForceMode2D.Impulse);
        }
        else
        {
            rigidBody.AddForce(Vector2.right * GameParameters.dashForce * -1, ForceMode2D.Impulse);
        }
        
        StartCoroutine(DashTime());
        StartCoroutine(Cooldown());

    }

    private IEnumerator DashTime()
    {
        yield return new  WaitForSeconds(GameParameters.dashForce * 0.01f);
        rigidBody.gravityScale = 1;
        playerState.changeState(global::playerState.Jumping);
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(GameParameters.dashCooldown);
        abilityOnCooldown = false;
    }
}
