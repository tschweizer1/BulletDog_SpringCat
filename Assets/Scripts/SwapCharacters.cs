using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwapCharacters : MonoBehaviour
{
    private PlayerState playerState;
    private PlayerInput playerInput;
    private InputAction SwapInput;
    public List<GameObject> Characters;

    private void Awake()
    {
        playerState = GetComponent<PlayerState>();
        playerInput = GetComponent<PlayerInput>();
    }

    public void OnSwapChar1()
    {
        SwapCharacter(1);
    }
    
    public void OnSwapChar2()
    {
        SwapCharacter(2);
    }
    
    public void OnSwapChar3()
    {
        SwapCharacter(3);
    }
    
    public void OnSwapChar4()
    {
        SwapCharacter(4);
    }

    private void SwapCharacter(int animal)
    {
        playerState.changeState(global::playerState.Swapping);
        GameObject swappedAnimal = Instantiate(Characters[animal-1], gameObject.transform.position, Quaternion.identity);
        swappedAnimal.GetComponent<Rigidbody2D>().AddForce(gameObject.GetComponent<Rigidbody2D>().linearVelocity, ForceMode2D.Impulse);
        Destroy(gameObject);
    }
}
