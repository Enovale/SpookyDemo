using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PhoneItem : MonoBehaviour
{
    public GameObject LightSource;
    public Image FillBar;
    [Range(0.0f, 5.0f)]
    public float DrainRate = 1.0f;
    public float Battery = 60;
    private float _maxBattery;

    private void Start()
    {
        _maxBattery = Battery;
        LightSource.SetActive(false);
    }

    private void Update()
    {
        FillBar.fillAmount = Battery / _maxBattery;
        
        if (Battery <= 0)
        {
            if (LightSource.activeInHierarchy)
                LightSource.SetActive(false);
            return;
        }

        if (Mouse.current.rightButton.wasPressedThisFrame)
            LightSource.SetActive(!LightSource.activeInHierarchy);

        if (LightSource.activeInHierarchy)
            Battery -= Time.deltaTime * DrainRate;
    }
}