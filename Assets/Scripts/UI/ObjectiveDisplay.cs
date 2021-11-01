using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectiveDisplay : MonoBehaviourSingleton<ObjectiveDisplay>
{
    [SerializeField]
    private TMP_Text ObjectiveMesh;

    public string CurrentObjective => _objective.Message;
    private DialogueMessage _objective;

    private readonly TypeWriter _writer = new TypeWriter();
    
    private void Awake()
    {
        Debug.Assert(ObjectiveMesh != null);
        ObjectiveMesh.text = "";
        _writer.Reverse = true;
    }

    private void Update()
    {
        _writer.Update(Time.deltaTime);

        if (_writer.JustWrote)
        {
            // TODO: Why the fuck is this here?
            //if (_writer.Done && _writer.Reverse && CurrentObjective != _writer.OriginalString)
            //    UpdateObjective(CurrentObjective, _objective.Color);

            ObjectiveMesh.text = _writer.TypedText;
        }
    }
    
    public void UpdateObjective(string text) => UpdateObjective(text, Color.white);

    public void UpdateObjective(string text, Color color)
    {
        _objective = new DialogueMessage(text, color, 0);
        
        if (_writer.Done && _writer.Reverse)
        {
            StartTypingObjective(text, color);
            return;
        }

        _writer.Reverse = true;
        _writer.Done = false;
        _writer.Delay = .025f;
    }

    public void ClearObjective()
    {
        if(_objective != null)
            UpdateObjective(CurrentObjective);
    }

    private void StartTypingObjective(string text, Color color)
    {
        ObjectiveMesh.color = color;
        _writer.Reset(text, .15f);
        ObjectiveMesh.ForceMeshUpdate();
        ObjectiveMesh.textInfo.ClearAllMeshInfo();
    }

    public void DirectSetDialogue(string text, Color? color = null)
    {
        _objective = new DialogueMessage(text, color ?? _objective.Color, 0);
        _writer.OriginalString = text;
        _writer.TypedText = text;
        ObjectiveMesh.color = color ?? _objective.Color;
        _writer.Done = true;
        _writer.Reverse = false;
    }
}
