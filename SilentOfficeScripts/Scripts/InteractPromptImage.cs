using UnityEngine;
using UnityEngine.UI;

public class InteractPromptImage : MonoBehaviour
{
    public GameObject interactCanvas;
    private bool playerInRange;

    void Start()
    {
        if (interactCanvas != null)
            interactCanvas.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 確保是玩家進入
        {
            playerInRange = true;

            if (interactCanvas != null)
                interactCanvas.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // 確保是玩家離開
        {
            playerInRange = false;

            if (interactCanvas != null)
                interactCanvas.SetActive(false);
        }
    }
}
