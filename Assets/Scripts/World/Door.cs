using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : DialogueObject
{
    public Animator DoorAnimator;
    public AudioSource SoundEmitter;
    public AudioClip OpenSound;
    public AudioClip CloseSound;
    public static readonly int Open = Animator.StringToHash("Open");

    private void Start()
    {
        Debug.Assert(DoorAnimator != null);
        Debug.Assert(SoundEmitter != null);
    }

    public void OpenDoor()
    {
        DoorAnimator.SetTrigger(Open);
        SoundEmitter.PlayOneShot(DoorAnimator.GetCurrentAnimatorStateInfo(0).IsName("Open") ? CloseSound : OpenSound);
    }
}