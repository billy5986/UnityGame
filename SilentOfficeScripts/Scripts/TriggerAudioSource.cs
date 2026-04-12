using UnityEngine;

public class TriggerAudioSource : MonoBehaviour
{
    private AudioSource audioSource;
    private bool hasPlayed = false; // 紀錄是否已播放

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasPlayed) // 只有玩家觸發，且還沒播放過
        {
            audioSource.Play();
            hasPlayed = true; // 設為已播放，防止再次觸發
        }
    }
}



