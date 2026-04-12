using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    public AudioSource audioSource;  // 音效來源
    public AudioClip footstepLoop;  // 腳步聲音檔

    void Start()
    {
        audioSource.loop = true; // 設置為循環播放
        audioSource.clip = footstepLoop; // 設定音效
    }

    void Update()
    {
        // 檢查是否按下移動鍵
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play(); // **開始播放腳步聲**
            }
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop(); // **停止播放腳步聲**
            }
        }
    }
}


