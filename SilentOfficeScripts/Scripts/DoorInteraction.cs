using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    public GameObject eKeyIcon; // E 键提示图标
    public GameObject door; // 门对象
    public GameObject passwordPanel; // 密码锁的 UI 面板
    private bool isNearDoor = false;

    void Start()
    {
        // 初始时确保 E 键图标处于隐藏状态
        eKeyIcon.SetActive(false);
    }

    void Update()
    {
        // 当玩家靠近门并按下 E 键时，打开密码锁 UI
        if (isNearDoor && Input.GetKeyDown(KeyCode.E))
        {
            eKeyIcon.SetActive(false); // 隐藏E键图标
            passwordPanel.SetActive(true); // 显示密码锁UI
        }
    }

    // 当玩家进入门的交互范围时
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNearDoor = true;
            eKeyIcon.SetActive(true); // 显示 E 键图标
        }
    }

    // 当玩家离开门的交互范围时
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNearDoor = false;
            eKeyIcon.SetActive(false); // 隐藏 E 键图标
        }
    }
}

