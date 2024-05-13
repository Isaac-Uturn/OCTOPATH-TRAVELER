using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField]
    Vector3 _interactionPointOffset = Vector3.zero;
    [SerializeField]
    float _interactionRadius = 1.0f;
    
    public LayerMask layerMask;

    readonly Collider[] _colliders = new Collider[3];

    private void Update()
    {
        int foundNum = Physics.OverlapSphereNonAlloc(transform.position + _interactionPointOffset, 
                                                    _interactionRadius, 
                                                    _colliders, 
                                                    layerMask);

        if (0 < foundNum)
        {
            IInteractable interactable = _colliders[0].GetComponent<IInteractable>();

            if (interactable != null
                && Keyboard.current.eKey.wasPressedThisFrame)
            {
                interactable.Interact(this);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position + _interactionPointOffset, Vector3.up, _interactionRadius);
    }
}
