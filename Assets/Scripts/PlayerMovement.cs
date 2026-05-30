using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerMovement : MonoBehaviour
{
    private float move;
    public float currentSpeed;
    private Rigidbody2D rigidBody;
    private Vector2 movement;
    private PlayerInput playerInput;
    private InputAction MoveInput;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        MoveInput = playerInput.actions["Move"];
    }

    void Update()
    {
        movement = MoveInput.ReadValue<Vector2>();
    }
    
    //if movement speed is + the character moves right, if - they move left
    void FixedUpdate()
    {
        
        if (movement.x != 0.0f)
        {
            move = (GameParameters.maxSpeed * Mathf.Sign(movement.x)) - rigidBody.linearVelocity.x;
        }
        else
        {
            move = rigidBody.linearVelocity.x * -1;
        }
        if((int)(Mathf.Sign(rigidBody.linearVelocity.x)) == (int)(movement.x) || rigidBody.linearVelocity.x == 0)
        {
            move *= GameParameters.accelerationRate;
        }
        else
        {
            move *= GameParameters.decelerationRate;
        }
        rigidBody.AddForce(Vector2.right * move, ForceMode2D.Impulse);
        
    }
}
