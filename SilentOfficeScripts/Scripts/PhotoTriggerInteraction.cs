using UnityEngine;
using UnityEngine.UI;

public class PhotoTriggerInteraction : MonoBehaviour
{
    public GameObject photoObject; // Photo物件
    public GameObject interactableUI; // 包含圖片和退出按鈕的UI
    private bool isPlayerNearby = false;
    public AudioSource audioSource;
    public AudioClip photoSound;

    void Start()
    {
        interactableUI.SetActive(false); // 初始時隱藏圖片UI
        Cursor.visible = false; // 開始時隱藏鼠標
        Cursor.lockState = CursorLockMode.Locked; // 鎖定鼠標
    }

    void Update()
    {
        // 當玩家在觸發區域內時，檢查是否按下E鍵
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            audioSource.PlayOneShot(photoSound);
            ShowImage(); // 顯示圖片並暫停遊戲
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has entered the trigger.");
            isPlayerNearby = true; // 標記玩家靠近
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has exited the trigger.");
            isPlayerNearby = false; // 玩家離開後取消標記
        }
    }

    void ShowImage()
    {
        interactableUI.SetActive(true); // 顯示圖片UI
        Time.timeScale = 0f; // 暫停遊戲
        Cursor.visible = true; // 顯示鼠標
        Cursor.lockState = CursorLockMode.None; // 解鎖鼠標
    }

    public void CloseImage()
    {
        interactableUI.SetActive(false); // 關閉圖片UI
        Time.timeScale = 1f; // 恢復遊戲
        Cursor.visible = false; // 隱藏鼠標
        Cursor.lockState = CursorLockMode.Locked; // 鎖定鼠標
    }
}
