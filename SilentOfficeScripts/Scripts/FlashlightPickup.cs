using UnityEngine;

public class FlashlightPickup : MonoBehaviour
{
    public GameObject interactCanvas;
    public ChangeUITextTMP changeUITextTMP;
    public AudioSource audioSource;  // 事先掛好並指定的 AudioSource

    private bool playerInRange;
    private FlashlightController playerFlashlight;
    public KeyPickup keyPickup;

    void Start()
    {
        if (interactCanvas != null)
            interactCanvas.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;

            if (interactCanvas != null)
                interactCanvas.SetActive(true);

            playerFlashlight = other.GetComponent<FlashlightController>();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;

            if (interactCanvas != null)
                interactCanvas.SetActive(false);
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            PickupFlashlight();
        }
    }

    void PickupFlashlight()
    {
        keyPickup.KeyBool();

        if (playerFlashlight != null)
            playerFlashlight.hasFlashlight = true;

        if (audioSource != null)
            audioSource.Play();

        if (changeUITextTMP != null)
            changeUITextTMP.OnFlashlightPickedUp();

        if (interactCanvas != null)
            interactCanvas.SetActive(false);

        if (audioSource != null)
            Destroy(gameObject, audioSource.clip.length);
        else
            Destroy(gameObject);
    }

}
