using UnityEngine;

public class GhostTrigger : MonoBehaviour
{
    public GameObject ghostPrefab;  // 鬼的預製體
    public Transform spawnPoint;    // 生成鬼的位置
    private GameObject ghostInstance; // 鬼的實例

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && ghostInstance == null)
        {
            Light playerLight = other.GetComponentInChildren<Light>();

            if (playerLight != null)
            {
                // 🔹 設置鬼的正確旋轉 (保持水平朝前)
                Quaternion correctRotation = Quaternion.Euler(-90, 0, -90);

                ghostInstance = Instantiate(ghostPrefab, spawnPoint.position, correctRotation);
                GhostAI ghostAI = ghostInstance.GetComponent<GhostAI>();

                if (ghostAI != null)
                {
                    ghostAI.SetPlayer(other.transform, playerLight);
                }
            }
            else
            {
                Debug.LogWarning("❌ 玩家相機內沒有找到 Spot Light！");
            }
        }
    }

}

