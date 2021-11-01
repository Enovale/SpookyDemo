using System;
using UnityEngine;

public class DialogueObject : InteractableObject
{
    public DialogueMessage[] Messages;
    [HideInInspector]
    public bool CancelDialogue = false;

    internal override bool IgnoreSizeChecks { get; } = false;
    private int _pointer = 0;

    public override void Interact()
    {
        CancelDialogue = false;
        base.Interact();
        if (Messages.Length <= 0)
            return;
        
        if (CancelDialogue)
            return;

        var msg = Messages[_pointer];
        DialogueDisplay.Instance.ShowDialogue(msg.Message, msg.Delay, msg.Color);
        
        if (CancelInteraction)
            return;

        if (Wrap)
            _pointer = ++_pointer % Messages.Length;
        else
            _pointer = Mathf.Clamp(++_pointer, 0, Messages.Length - 1);
    }

    private void Reset()
    {
        Messages = new DialogueMessage[1] {new DialogueMessage()};
    }
}