using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour, IInteractable
{
    public virtual void EndHover()
    {
    }

    public virtual void Interaction()
    {
    }

    public virtual void StartHover()
    {
    }
}