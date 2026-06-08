using System;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private BoxCollider2D InteractableCollider;
    private LayerMask InteractableLayers;
    public float distance;

    private void Awake()
    {
        InteractableCollider =  GameObject.Find("InteractableCollider").GetComponent<BoxCollider2D>();
        InteractableLayers =  LayerMask.GetMask("Interactable");
    }
    
    public Collider2D IsInteractablePresent()
    {
        
    
        return Physics2D.OverlapBox(
            InteractableCollider.bounds.max,   // top of the box in world space
            InteractableCollider.size,     // width and height of the box
            distance,                             // rotation of the box (0 = no rotation)
            InteractableLayers               // only detect these layers
        );
    }

    public void OnInteract()
    {
        if (IsInteractablePresent() == null)
        {
            print("no object");
            return;
        }
        InteractableObject interactableObject = IsInteractablePresent().gameObject.GetComponent<InteractableObject>();
        interactableObject.Interact();
    }
}
