using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public AudioSource audioSource; // ­µ·½

    void Start()
    {
        Button btn = GetComponent<Button>();
        if (btn != null)
            btn.onClick.AddListener(PlaySound);
    }

    void PlaySound()
    {
        if (audioSource != null)
            audioSource.Play();
    }
}

