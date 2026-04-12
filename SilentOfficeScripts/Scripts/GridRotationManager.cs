using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GridRotationManager : MonoBehaviour
{
    public GameObject[] gridCells; // 存放25格的格子
    private int[] rotationStates; // 儲存每格旋轉狀態
    public Text completionText; // 顯示完成狀態的文字
    public Button closeButton; // 手動關閉的按鈕

    void Start()
    {
        rotationStates = new int[gridCells.Length];

        // 隨機初始化每格旋轉角度
        for (int i = 0; i < gridCells.Length; i++)
        {
            int randomRotation = Random.Range(1, 4); // 隨機選擇1-3次90度旋轉
            rotationStates[i] = randomRotation;
            gridCells[i].transform.rotation = Quaternion.Euler(0, 0, randomRotation * 90);

            // 添加點擊事件
            int index = i; // 防止閉包問題
            gridCells[i].GetComponent<Button>().onClick.AddListener(() => RotateCell(index));
        }

        // 初始時隱藏完成文字
        if (completionText != null)
        {
            completionText.gameObject.SetActive(false);
        }

        // 關閉按鈕連結
        closeButton.onClick.AddListener(OnClosePuzzle);
    }

    void RotateCell(int index)
    {
        // 旋轉90度
        rotationStates[index] = (rotationStates[index] + 1) % 4;
        gridCells[index].transform.rotation = Quaternion.Euler(0, 0, rotationStates[index] * 90);

        // 檢查是否完成
        CheckCompletion();
    }

    void CheckCompletion()
    {
        foreach (int state in rotationStates)
        {
            if (state != 0)
            {
                // 如果未完成，隱藏完成文字
                if (completionText != null)
                {
                    completionText.gameObject.SetActive(false);
                }
                return;
            }
        }

        Debug.Log("拼圖已完成！");
        if (completionText != null)
        {
            completionText.gameObject.SetActive(true); // 顯示完成文字
        }
    }

    void OnClosePuzzle()
    {
        Debug.Log("玩家關閉拼圖 UI。");

        // 恢復玩家控制
        UnlockPlayerControl();

        // 關閉UI（按鈕的操作）
        gameObject.SetActive(false);
    }

    void UnlockPlayerControl()
    {
        // 清除UI焦點
        EventSystem.current?.SetSelectedGameObject(null);

        // 解鎖滑鼠
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Debug.Log($"滑鼠狀態更新：{Cursor.lockState}, 可見性：{Cursor.visible}");

        // 啟用玩家移動
        var playerController = FindObjectOfType<PlayerController>();
        if (playerController != null)
        {
            playerController.enabled = true; // 啟用玩家控制
            Debug.Log("玩家控制已啟用。");
        }
        else
        {
            Debug.LogWarning("未找到玩家控制腳本！");
        }

        // 確保遊戲時間恢復
        Time.timeScale = 1; // 確保遊戲時間恢復流暢
        Debug.Log("遊戲時間恢復。");
    }
}
