using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathFlashlightController : MonoBehaviour
{
    public Light flashlight;
    public bool hasFlashlight = true;

    void Start()
    {
        flashlight.enabled = true;
    }

    void Update()
    {
        if (!hasFlashlight) return;

        if (Input.GetKeyDown(KeyCode.F))
        {
            flashlight.enabled = !flashlight.enabled;
        }
    }
}
