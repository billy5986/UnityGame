using UnityEngine;

public class DoorAutoOpen : MonoBehaviour
{
    public GameObject doorTrigger; // 門的觸發區域物件
    public float openAngle = 90f; // 開門的角度
    public float openSpeed = 2f; // 開門旋轉速度

    private Quaternion closedRotation; // 門關閉時的旋轉
    private Quaternion openRotation; // 門打開時的旋轉
    private bool isDoorOpen = false; // 標記門是否打開
    private bool isAnimating = false; // 標記是否正在動畫

    void Start()
    {
        if (doorTrigger == null)
        {
            Debug.LogError("DoorTrigger is not assigned.");
            return;
        }

        // 設置關閉和打開的旋轉角度
        closedRotation = transform.rotation;
        openRotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, openAngle, 0));
    }

    void Update()
    {
        // 檢查門是否需要開啟動畫
        if (isAnimating)
        {
            Quaternion targetRotation = isDoorOpen ? openRotation : closedRotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * openSpeed);

            // 檢查是否達到目標旋轉
            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
            {
                transform.rotation = targetRotation; // 修正到精確位置
                isAnimating = false; // 停止動畫
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isDoorOpen)
        {
            Debug.Log("Player entered trigger, door opening."); // 測試訊息
            isDoorOpen = true; // 標記門為開啟狀態
            isAnimating = true; // 開始開門動畫
        }
    }

    // 移除 OnTriggerExit 方法，防止門在玩家離開後關閉
}
