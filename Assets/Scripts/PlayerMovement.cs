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
    void FixedUpdate()
    {
        move = movement.x * 5;
        rigidBody.AddForce(Vector2.right * move, ForceMode2D.Force);
    }
}
