using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    
    public void OnJump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * GameParameters.jumpForce,  ForceMode2D.Impulse);
    }
}
