using System;
using UnityEngine;

public class ButtonInteractable : MonoBehaviour, InteractableObject
{
    public GameObject objectToTrigger;
    private TriggerableObject triggerableObject;

    private void Awake()
    {
        triggerableObject = objectToTrigger.GetComponent<TriggerableObject>();
    }

    public void Interact()
    {
        if (triggerableObject == null)
        {
            print("nuh uh you forgor to hook up the triggerable object punk");
            return;
        }
        triggerableObject.Trigger();
    }
}
