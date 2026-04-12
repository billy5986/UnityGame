using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("OpeningVideo"); // 切換到遊戲場景
    }

    public void QuitGame()
    {
        Application.Quit(); // 退出遊戲
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // 在 Unity Editor 停止播放
#endif
    }
}

