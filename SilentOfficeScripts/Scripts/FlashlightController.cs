using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    public Light flashlight;
    public bool hasFlashlight = false;

    void Start()
    {
        flashlight.enabled = false; // 一開始不能開
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


