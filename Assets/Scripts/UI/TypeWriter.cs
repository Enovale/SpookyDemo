using UnityEngine;

public class TypeWriter
{
    public string TypedText;
    public string OriginalString;
    public float Delay;
    public bool Reverse;
    public bool JustWrote;
    public bool Done;

    private float _timer;
    private int _pointer;

    public TypeWriter() => Reset("", 0);

    public TypeWriter(string text, float delay) => Reset(text, delay);

    public void Reset() => Reset(OriginalString, Delay);

    public void Reset(string text, float delay)
    {
        OriginalString = text;
        Delay = delay;
        TypedText = "";
        _timer = _pointer = 0;
        Done = JustWrote = Reverse = false;

        if (OriginalString == "")
            Done = true;
    }
    
    public void Update(float delta)
    {
        JustWrote = false;
        if (Done)
            return;

        if (Time.fixedTime > _timer)
        {
            if (Reverse)
                TypedText = TypedText.Substring(0, TypedText.Length - 1);
            else
                TypedText += OriginalString[_pointer];
            _pointer += Reverse ? -1 : 1;
            _timer = Time.fixedTime + Delay;
            JustWrote = true;
        }
        
        if (Reverse && TypedText.Length <= 0 || !Reverse && _pointer >= OriginalString.Length)
            Done = true;
    }
}