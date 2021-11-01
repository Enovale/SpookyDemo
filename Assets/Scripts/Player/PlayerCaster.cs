using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCaster : MonoBehaviour
{
    public GameObject SelectedObject;
    [Range(0, 10)]
    public float CastDistance = 5;

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame && SelectedObject != null)
        {
            SelectedObject.GetComponent<InteractableObject>()?.Interact();    
        }
    }

    private void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out var hit,
            CastDistance, (1 << 6) | 1))
            SelectedObject = hit.collider.gameObject.layer != 0 ? hit.transform.gameObject : null;
        else
            SelectedObject = null;
    }
}