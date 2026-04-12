using UnityEngine;

public class PuzzleInteraction : MonoBehaviour
{
    public GameObject puzzleUI; // 連結到拼圖 UI
    public KeyCode interactKey = KeyCode.E; // 互動按鍵
    private bool isPlayerNear = false;      // 玩家是否在互動範圍內
    private bool isPuzzleActive = false;   // 拼圖是否正在進行
    public ChangeUITextTMP changeUITextTMP;
    public AudioSource audioSource;
    public AudioClip audioClip;

    void Update()
    {
        // 玩家在範圍內按下互動鍵且拼圖未激活
        if (isPlayerNear && Input.GetKeyDown(interactKey) && !isPuzzleActive)
        {
            TogglePuzzleUI(true); // 開啟拼圖
            changeUITextTMP.EnterPassword();
            audioSource.PlayOneShot(audioClip);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true; // 玩家進入範圍
            Debug.Log("玩家進入互動範圍");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false; // 玩家離開範圍
            Debug.Log("玩家離開互動範圍");
        }
    }

    public void TogglePuzzleUI(bool state)
    {
        puzzleUI.SetActive(state); // 顯示或隱藏拼圖 UI
        isPuzzleActive = state;    // 更新拼圖狀態
        Time.timeScale = state ? 0 : 1; // 暫停或恢復時間流動

        if (state)
        {
            Cursor.lockState = CursorLockMode.None; // 解鎖鼠標
            Cursor.visible = true;                 // 顯示鼠標
            Debug.Log("拼圖開啟，鼠標已解鎖並顯示。");
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked; // 鎖定鼠標
            Cursor.visible = false;                  // 隱藏鼠標
            Debug.Log("拼圖關閉，鼠標已鎖定並隱藏。");
        }

        // 玩家控制恢復或禁用
        TogglePlayerControl(!state);
    }

    public void ExitPuzzle()
    {
        TogglePuzzleUI(false); // 關閉拼圖 UI
    }

    private void TogglePlayerControl(bool enable)
    {
        // 找到玩家控制腳本並啟用或禁用它
        var playerController = FindObjectOfType<PlayerController>();
        if (playerController != null)
        {
            playerController.enabled = enable;
            Debug.Log($"玩家控制已 {(enable ? "啟用" : "禁用")}");
        }
        else
        {
            Debug.LogWarning("未找到玩家控制腳本！");
        }
    }
}
