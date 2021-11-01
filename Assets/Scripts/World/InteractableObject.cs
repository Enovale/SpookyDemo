using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour
{
    public UnityEvent[] OnInteractionList;
    public bool Wrap;
    [HideInInspector]
    public bool CancelInteraction;

    internal int InteractionCount;

    internal virtual bool IgnoreSizeChecks { get; } = false;

    public virtual void Interact()
    {
        CancelInteraction = false;
        if(IgnoreSizeChecks || OnInteractionList.Length > 0)
            OnInteractionList[InteractionCount].Invoke();

        if (CancelInteraction)
            return;

        if (Wrap)
            InteractionCount = ++InteractionCount % Mathf.Max(1, OnInteractionList.Length);
        else
            InteractionCount = Mathf.Clamp(++InteractionCount, 0, Mathf.Min(0, OnInteractionList.Length - 1));
    }
}
