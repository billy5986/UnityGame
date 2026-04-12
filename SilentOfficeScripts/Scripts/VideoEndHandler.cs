using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoEndHandler : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string sceneToLoad = "MainMenu";

    void Start()
    {
        if (videoPlayer == null)
            videoPlayer = GetComponent<VideoPlayer>();

        // 當影片播放結束時觸發事件
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // 確保滑鼠在回主選單前被重新啟用
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        // 載入指定場景
        SceneManager.LoadScene(sceneToLoad);
    }
}

