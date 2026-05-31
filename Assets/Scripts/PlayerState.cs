using UnityEngine;

public enum playerState
{
    Grounded,
    Jumping,
    Falling,
    Ability,
    Swapping
}

public class PlayerState : MonoBehaviour
{
    private playerState state;

    public void changeState(playerState newState)
    {
        state = newState;
    }

    public playerState currentState()
    {
        return state;
    }
    
}
