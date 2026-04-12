using UnityEngine;
using UnityEngine.UI;

public class PasswordDoorController : MonoBehaviour
{
    public GameObject door;   // 門
    public GameObject keypadUI; // 密碼鎖 UI
    public Text displayText;  // 顯示輸入的密碼
    public string correctPassword = "1234"; // 正確密碼
    private string currentPassword = "";    // 當前輸入的密碼
    private bool isDoorOpen = false;        // 門是否打開

    private void Start()
    {
        // 確保在遊戲開始時密碼鎖 UI 是隱藏的
        keypadUI.SetActive(false);
    }

    private void Update()
    {
        // 檢查玩家是否靠近並按下 E 鍵進行互動
        if (!isDoorOpen && Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < 3f && Input.GetKeyDown(KeyCode.E))
        {
            InteractWithLock();  // 進入密碼鎖UI
        }
    }

    // 與密碼鎖交互的邏輯
    void InteractWithLock()
    {
        keypadUI.SetActive(true);  // 顯示密碼鎖UI

        // 讓玩家無法移動並顯示鼠標
        Time.timeScale = 0;  // 暫停遊戲
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // 離開密碼鎖交互的邏輯，通過按鈕觸發
    public void ExitInteraction()
    {
        keypadUI.SetActive(false);  // 隱藏密碼鎖UI

        // 恢復遊戲時間並隱藏鼠標
        Time.timeScale = 1;  // 恢復遊戲
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // 添加數字
    public void AddNumber(string number)
    {
        if (currentPassword.Length < 4)
        {
            currentPassword += number;
            UpdateDisplay();
        }
    }

    // 清除密碼
    public void ClearPassword()
    {
        currentPassword = "";
        UpdateDisplay();
    }

    // 更新顯示密碼
    void UpdateDisplay()
    {
        displayText.text = currentPassword;
    }

    // 檢查密碼是否正確
    public void CheckPassword()
    {
        if (currentPassword == correctPassword)
        {
            Debug.Log("Correct password!");
            OpenDoor();
        }
        else
        {
            Debug.Log("Incorrect password!");
            ClearPassword();
        }
    }

    // 開門邏輯
    void OpenDoor()
    {
        if (!isDoorOpen)
        {
            door.transform.Rotate(0, 90, 0);  // 開門
            isDoorOpen = true;
            ExitInteraction();  // 關閉UI
        }
    }
}
