using UnityEngine;
using UnityEngine.UI;

public class ChangeUITextTMP : MonoBehaviour
{
    public Text uiText;
    public int cluesCount;
    public int cluesCurrentCount = 0;

    private string findFlashlightText = "任務:尋找手電筒";
    private string findKeyText = "任務:尋找鑰匙卡";
    private string openDoorText = "任務:已取得鑰匙卡";
    private string findCluesText = "任務:尋找線索";
    private string meetingRoomText = "任務:打開會議室";
    private string enterPassword = "任務:尋找密碼鎖，並輸入密碼";

    public MeetingDoorController meetingDoorController;

    private void Start()
    {
        if (uiText != null)
        {
            uiText.text = findFlashlightText;
        }
    }

    // 撿到手電筒時呼叫
    public void OnFlashlightPickedUp()
    {
        if (uiText != null)
        {
            uiText.text = findKeyText;
        }
    }

    public void OnKeyPickedUp()
    {
        if (uiText != null)
            uiText.text = openDoorText;
    }

        private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (uiText != null)
            {
                uiText.text = findCluesText + cluesCurrentCount + "/" + cluesCount.ToString();
            }
        }
    }

    public void FindClues()
    {
        cluesCurrentCount++;
        uiText.text = findCluesText + cluesCurrentCount + "/" + cluesCount.ToString();
        if (cluesCurrentCount == cluesCount)
        {
            uiText.text = meetingRoomText;
            meetingDoorController.Boolchange();
        }
    }

    public void EnterPassword()
    {
        uiText.text = enterPassword;
    }
    
}
