using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DialogueMessage
{
    public string Message;
    public Color Color;
    public float Delay;

    public DialogueMessage(string text, Color color, float delay)
    {
        Message = text;
        Color = color;
        Delay = delay;
    }

    public DialogueMessage()
    {
        Message = "";
        Color = Color.white;
        Delay = 0.25f;
    }
}
