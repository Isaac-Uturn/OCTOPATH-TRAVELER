using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public interface IInteractable
{
    public bool Interact(Interactor interactor);

    //bool IsInteract { get; set; }
}
