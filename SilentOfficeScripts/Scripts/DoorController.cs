using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour
{
    public float openAngle = 90f;
    public float speed = 2f;
    private bool isOpen = false;
    public bool keyPickup = false;

    private Quaternion startRot;
    private Quaternion endRot;

    private void Start()
    {
        startRot = transform.rotation;
        endRot = startRot * Quaternion.Euler(0, openAngle, 0);
    }

    public void Boolchange()
    {
        keyPickup = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!isOpen && other.CompareTag("Player") && keyPickup == true)
        {
            StartCoroutine(OpenDoor());
        }
    }

    private IEnumerator OpenDoor()
    {
        isOpen = true;
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * speed;
            transform.rotation = Quaternion.Lerp(startRot, endRot, t);
            yield return null;
        }
        Debug.Log("門已打開");
    }
}

