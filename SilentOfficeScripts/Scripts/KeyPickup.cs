using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public GameObject interactCanvas;
    public ChangeUITextTMP changeUITextTMP;
    public DoorController doorController;
    public DoorControllerRight doorControllerRight;
    public GameObject key;

    public AudioSource audioSource;  // 事先掛好並指定的 AudioSource

    private bool playerInRange;

    void Start()
    {
        key.SetActive(false);
        if (interactCanvas != null)
            interactCanvas.SetActive(false);
    }

    public void KeyBool()
    {
        key.SetActive(true);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;

            if (interactCanvas != null)
                interactCanvas.SetActive(true);
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
            PickupKey();
        }
    }

    void PickupKey()
    {
        PlayerController player = FindObjectOfType<PlayerController>();
        if (player != null)
            player.hasKey = true;

        if (audioSource != null)
            audioSource.Play();  // 用已掛 AudioSource 播音效

        if (changeUITextTMP != null)
            changeUITextTMP.OnKeyPickedUp();

        if (interactCanvas != null)
            interactCanvas.SetActive(false);

        doorController.Boolchange();
        doorControllerRight.Boolchange();

        // 延遲刪除，確保音效能完整播放
        if (audioSource != null)
            Destroy(gameObject, audioSource.clip.length);
        else
            Destroy(gameObject);
    }
}
