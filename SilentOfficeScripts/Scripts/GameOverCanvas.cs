using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverCanvas : MonoBehaviour
{
    public string PlayerDeathScenes = "GameScene";
    public string mainMenuScene = "MainMenu";
    private void OnEnable()
    {
        // 🔹 顯示並解鎖滑鼠
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void RestartGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f; // 恢復時間
        SceneManager.LoadScene(PlayerDeathScenes);
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1f; // 恢復時間
        SceneManager.LoadScene(mainMenuScene);
    }
}
