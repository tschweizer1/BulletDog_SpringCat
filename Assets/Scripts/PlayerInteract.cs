using System;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private BoxCollider2D InteractableCollider;
    private LayerMask InteractableLayers;

    private void Awake()
    {
        InteractableCollider =  GameObject.Find("InteractableCollider").GetComponent<BoxCollider2D>();
        InteractableLayers =  LayerMask.GetMask("Interactable");
    }
    
    public bool IsInteractablePresent()
    {
        
    
        return Physics2D.OverlapBox(
            InteractableCollider.bounds.center,   // centre of the box in world space
            InteractableCollider.bounds.size,     // width and height of the box
            0f,                             // rotation of the box (0 = no rotation)
            InteractableLayers                // only detect these layers
        );
    }

    public void OnInteract()
    {
        if (IsInteractablePresent())
        {
            print("Interactable found");
        }
        else
        {
            print("Interactable NOT found");
        }
    }
}
