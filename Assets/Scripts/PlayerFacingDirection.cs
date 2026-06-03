using System;
using UnityEngine;

public class PlayerFacingDirection : MonoBehaviour
{
    public bool isFacingRight;
    private Rigidbody2D rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 movement = rigidBody.linearVelocity;
        if (isFacingRight && movement.x < -0.1f || !isFacingRight && movement.x > 0.1f)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }
}
