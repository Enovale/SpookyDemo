using System;
using System.Collections;
using System.Collections.Generic;
using Fragsurf.Movement;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bed : InteractableObject
{
    public Image FadeImage;
    public float SleepTime = 10;
    public Camera SleepCam;
    [SerializeField]
    private bool _isSleeping = false;
    [SerializeField]
    private float _fadeAmount = 0.0f;

    private GameObject _player;

    internal override bool IgnoreSizeChecks { get; } = false;

    private void Start()
    {
        _player = FindObjectOfType<SurfCharacter>().gameObject;
        SleepCam.gameObject.SetActive(false);
    }

    public override void Interact()
    {
        if (_isSleeping)
            return;
        
        _isSleeping = true;
        
        SleepCam.gameObject.SetActive(true);
        _player.SetActive(false);
        DialogueDisplay.Instance.ShowDialogue("SPACE to get up", 0.025f, Color.gray);
        
        if (!FlagTracker.Instance.StartedSleeping)
            ScriptedEvents.Instance.StartSleep();
        FlagTracker.Instance.StartedSleeping = true;
        base.Interact();
    }

    // Update is called once per frame
    void Update()
    {
        FadeImage.color = new Color(FadeImage.color.r, FadeImage.color.g, FadeImage.color.b, Mathf.Max(0, _fadeAmount));
        
        if (_isSleeping)
        {
            var mDelta = Mouse.current.delta.ReadValue();
            if (mDelta.x <= 0 && mDelta.y <= 0)
                _fadeAmount += Time.deltaTime / SleepTime;
            else
                _fadeAmount = -0.2f;

            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                _fadeAmount = 0;
                _isSleeping = false;
                _player.SetActive(true);
                SleepCam.gameObject.SetActive(false);
                ScriptedEvents.Instance.StopKnocking();
            }
        }

        // Load next scene once sleeping
        if (_fadeAmount >= 1.0f)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
