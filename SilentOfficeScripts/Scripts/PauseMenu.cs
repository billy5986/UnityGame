using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // 場景管理命名空間

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // 暫停視窗 UI
    private bool isPaused = false; // 是否暫停

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // 按下 ESC
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true); // 顯示視窗
        Time.timeScale = 0f; // 暫停遊戲
        isPaused = true;
        Cursor.lockState = CursorLockMode.None; // 解鎖滑鼠
        Cursor.visible = true; // 顯示滑鼠
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false); // 隱藏視窗
        Time.timeScale = 1f; // 恢復遊戲
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked; // 鎖定滑鼠
        Cursor.visible = false; // 隱藏滑鼠
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // 確保時間恢復正常
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // 重新載入當前場景
    }

    public void QuitGame()
    {
        Application.Quit(); // 退出遊戲
        Debug.Log("退出遊戲"); // 在編輯器模式下顯示訊息
    }

    // 🔽 新增的方法：回到主選單
    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // 確保時間恢復正常
        SceneManager.LoadScene("MainMenu"); // 載入主選單場景，請確認 MainMenu 場景有加入 Build Settings
    }
}
