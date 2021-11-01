using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[RequireComponent(typeof(Collider))]
public class ScriptableTrigger : MonoBehaviour
{
    public UnityEvent OnEnter;
    public UnityEvent OnExit;
    public float Delay;
    
    private Collider _col;
    
    private void Awake()
    {
        _col = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            StartCoroutine(InvokeAfterDelay(Delay, OnEnter));
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            StartCoroutine(InvokeAfterDelay(Delay, OnExit));
        }
    }

    IEnumerator InvokeAfterDelay(float time, UnityEvent action)
    {
        yield return new WaitForSeconds(time);
        action.Invoke();
    }
}
