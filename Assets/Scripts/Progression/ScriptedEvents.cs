using System;
using System.Collections;
using System.Collections.Generic;
using Fragsurf.Movement;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using LightType = UnityEngine.LightType;
using Random = UnityEngine.Random;

public class ScriptedEvents : MonoBehaviourSingleton<ScriptedEvents>
{
    public AudioSource FirstKnockingSource;
    public AudioSource SecondKnockingSource;
    public AudioClip[] FirstKnocks;
    public AudioClip[] SecondsKnocks;
    public GameObject KrystDoor;
    public Animator KrystAnimator;
    public Image FadeImage;
    [HideInInspector] public GameObject OwnerObject;
    private Coroutine _knockRoutine1;
    private Coroutine _knockRoutine2;
    private SurfCharacter _player;
    private GameObject _phone;
    private float _fadeAmount;
    private Coroutine _finalDialogueRoutine;

    private string _homeworkObjective => $"Fix {FlagTracker.Instance.HomeworkLeft} more mistakes";

    private void Awake()
    {
        OwnerObject = gameObject;
        _phone = FindObjectOfType<PhoneItem>(true).gameObject;
        _player = FindObjectOfType<SurfCharacter>(true);
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            ObjectiveDisplay.Instance.UpdateObjective("Make yourself something to eat.");
            DialogueDisplay.Instance.ShowDialogue("Phew. Finally home.", 0.05f, Color.black);
        }
        else if (SceneManager.GetActiveScene().name == "Finale")
        {
            ObjectiveDisplay.Instance.UpdateObjective("Stop this.");
        }
    }

    private void Update()
    {
        if (KrystAnimator != null)
        {
            var currentKrystAnim = KrystAnimator.GetCurrentAnimatorStateInfo(0);
            if (currentKrystAnim.IsName("Spooky") && currentKrystAnim.normalizedTime >= 0.99f)
            {
                RestartLevel();
                FlagTracker.Instance.Reset();
            }
        }

        if (FlagTracker.Instance.Falling)
        {
            _fadeAmount += Time.deltaTime / 2;
            FadeImage.color = new Color(FadeImage.color.r, FadeImage.color.g, FadeImage.color.b,
                Mathf.Max(0, _fadeAmount));
            if (_player.moveConfig.gravity > 0)
                _player.moveConfig.gravity -= Time.deltaTime * 25;
        }
    }

    public void RestartLevel()
    {
        if (!FlagTracker.Instance.BirdsAndTheBees)
        {
            FlagTracker.Instance.Reset();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            StartCoroutine(BlackCrash());
        }
    }

    public void PickUpBurger() => FlagTracker.Instance.HasBurger = true;

    public void StartMicrowave(DialogueObject sender)
    {
        if (FlagTracker.Instance.HasBurger && _phone.activeInHierarchy && !FlagTracker.Instance.BurgerCooked &&
            !FlagTracker.Instance.BurgerCooking)
        {
            _phone.SetActive(false);
            FlagTracker.Instance.HasBurger = false;
            FlagTracker.Instance.BurgerCooking = true;
            ObjectiveDisplay.Instance.UpdateObjective("Wait.");
            sender.GetComponent<AudioSource>().Play();
            StartCoroutine(MicrowaveCooking());
        }
        else if (FlagTracker.Instance.BurgerCooking)
        {
            DialogueDisplay.Instance.ShowDialogue(
                "Unfortunately, willing the food into submission does not appear to yield anything.", 0.05f,
                Color.black);
            sender.CancelInteraction = true;
            sender.CancelDialogue = true;
        }
        else if (!FlagTracker.Instance.BurgerCooked)
        {
            DialogueDisplay.Instance.ShowDialogue(
                "It's a microwave. Instead of making small waves, it just makes things hot.", 0.05f, Color.black);
            sender.CancelInteraction = true;
            sender.CancelDialogue = true;
        }
    }

    IEnumerator MicrowaveCooking()
    {
        yield return new WaitForSeconds(10); // TODO
        FlagTracker.Instance.BurgerCooked = true;
        FlagTracker.Instance.BurgerCooking = false;
        _phone.SetActive(true);
        ObjectiveDisplay.Instance.UpdateObjective("Sleep.");
    }

    public void StartSleep()
    {
        // Set the mood
        var lights = FindObjectsOfType<Light>();
        foreach (var source in lights)
        {
            if (source.type == LightType.Point)
            {
                source.intensity /= 10;
                source.transform.parent.GetComponent<Renderer>().material
                    .SetColor("_EmissionColor", new Color(.25f, .25f, .25f));
            }
        }

        var doors = FindObjectsOfType<Door>();
        foreach (var door in doors)
        {
            if (door.DoorAnimator.GetCurrentAnimatorStateInfo(0).IsName("Open"))
                door.DoorAnimator.SetTrigger(Door.Open);
        }

        // Sounds weird when it plays immediately after sleeping
        //FirstKnockingSource.PlayOneShot(FirstKnocks[Random.Range(0, FirstKnocks.Length)]);
        _knockRoutine1 = StartCoroutine(FirstKnockLoop(4));
    }

    IEnumerator FirstKnockLoop(int timesLeft)
    {
        if (timesLeft < 0)
        {
            yield return new WaitForSeconds(3);
            _knockRoutine2 = StartCoroutine(SecondKnockLoop());
            yield break;
        }

        yield return new WaitForSeconds(Random.Range(3, 7));

        FirstKnockingSource.PlayOneShot(FirstKnocks[Random.Range(0, FirstKnocks.Length)]);
        _knockRoutine1 = StartCoroutine(FirstKnockLoop(--timesLeft));
    }

    IEnumerator SecondKnockLoop()
    {
        yield return new WaitForSeconds(Random.Range(2, 4));

        SecondKnockingSource.PlayOneShot(SecondsKnocks[Random.Range(0, SecondsKnocks.Length)]);
        _knockRoutine2 = StartCoroutine(SecondKnockLoop());
    }

    public void StopKnocking()
    {
        StopCoroutine(_knockRoutine1);
        StopCoroutine(_knockRoutine2);
    }

    public void OpenDoorForKryst()
    {
        if (FlagTracker.Instance.StartedSleeping)
        {
            FirstKnockingSource.Stop();
            SecondKnockingSource.Stop();
            StopAllCoroutines();

            // Set the mood *harder*
            var lights = FindObjectsOfType<Light>();
            foreach (var source in lights)
            {
                if (source.type == LightType.Point)
                {
                    source.intensity = 0;
                    source.transform.parent.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
                }

                // Begone with the sun
                if (source.type == LightType.Directional)
                {
                    source.intensity = 0.01f;
                }
            }

            KrystDoor.layer = 6;
        }
    }

    public void StartSchoolSequence()
    {
        ObjectiveDisplay.Instance.UpdateObjective(_homeworkObjective);
    }

    public void StartFinale()
    {
        _finalDialogueRoutine = StartCoroutine(FinaleDialogue());
    }

    IEnumerator FinaleDialogue()
    {
        yield return new WaitForSeconds(2);
        DialogueDisplay.Instance.ShowDialogue("Can you see it?", 0.25f, Color.white);
        yield return new WaitForSeconds(6);
        DialogueDisplay.Instance.ShowDialogue("I know you do.", 0.15f, Color.white);
        yield return new WaitForSeconds(6);
        DialogueDisplay.Instance.ShowDialogue("I think you just need someone to give you a little push.", 0.15f,
            Color.white);
        yield return new WaitForSeconds(2);
        FlagTracker.Instance.BirdsAndTheBees = true;
    }

    public void StartFalling(AudioSource source)
    {
        if (FlagTracker.Instance.BirdsAndTheBees)
        {
            source.Play();
            FlagTracker.Instance.Falling = true;
            StartCoroutine(PostDialogue());
        }
        else
        {
            StopCoroutine(_finalDialogueRoutine);
            DialogueDisplay.Instance.ShowDialogue("Tsk Tsk.", 0.1f, Color.white);
        }
    }

    IEnumerator PostDialogue()
    {
        yield return new WaitForSeconds(1);
        StopCoroutine(_finalDialogueRoutine);
        DialogueDisplay.Instance.ShowDialogue("See? Doesn't that feel so much better already?", 0.1f, Color.white);
    }

    IEnumerator BlackCrash()
    {
        yield return new WaitForSeconds(6);
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}