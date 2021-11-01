using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueDisplay : MonoBehaviourSingleton<DialogueDisplay>
{
    [SerializeField]
    private TMP_Text DialogueMesh;

    private readonly TypeWriter _writer = new TypeWriter();
    
    private void Start()
    {
        Debug.Assert(DialogueMesh != null);
        DialogueMesh.text = "";
    }

    private void Update()
    {
        _writer.Update(Time.deltaTime);

        if (_writer.JustWrote)
        {
            if (_writer.Done && !_writer.Reverse)
                StartCoroutine(WriterTimeout(2));
            DialogueMesh.text = _writer.TypedText;
        }
    }

    private IEnumerator WriterTimeout(float timeout)
    {
        yield return new WaitForSeconds(timeout);
        if (_writer.Done && !_writer.Reverse)
        {
            _writer.Done = false;
            _writer.Reverse = true;
            _writer.Delay = 0.025f;
        }
    }

    public void ShowDialogue(string text, float delay = .25f, Color? color = null)
    {
        DialogueMesh.color = color ?? Color.white;
        _writer.Reset(text, delay);
        DialogueMesh.ForceMeshUpdate();
        DialogueMesh.textInfo.ClearAllMeshInfo();
    }
}
