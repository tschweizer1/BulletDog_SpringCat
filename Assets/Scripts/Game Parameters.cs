using UnityEngine;

public static class GameParameters
{
    //Player Movement Parameters
    public static float accelerationRate = 0.05f;
    public static float decelerationRate = 0.2f;
    public static float maxSpeed = 8.0f;
    public static float jumpForce = 6.0f;
    
    
    //Character Ability Parameters
    public static float dashForce = 50.0f;
    public static float dashCooldown = 1.0f;
    public static float springJumpForce = 10.0f;
    public static float springJumpCooldown = 2.0f;
}
