using UnityEngine;
using UnityEngine.UI;

public class MusicTriggerPopup : MonoBehaviour
{
    public AudioSource audioSource;       // 指向音樂 AudioSource
    public GameObject popupPanel;         // UI Panel 視窗
    private bool hasShown = false;        // 確保只顯示一次

    void Update()
    {
        if (!hasShown && !audioSource.isPlaying && audioSource.time > 0f)
        {
            hasShown = true;
            ShowPopup();
        }
    }

    void ShowPopup()
    {
        popupPanel.SetActive(true);
        Invoke("HidePopup", 0.5f); // 1秒後關閉
    }

    void HidePopup()
    {
        popupPanel.SetActive(false);
    }
}

