using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorRotationSceneLoader : MonoBehaviour
{
    public Transform doorTransform;
    public string targetSceneName = "EndingVideo";
    public float angleThreshold = 1f; // 容差值，防止浮點誤差

    void Update()
    {
        Vector3 currentRotation = doorTransform.eulerAngles;

        // 處理角度接近 90 的誤差（例如 89.9、90.1）
        bool isYAt90 = Mathf.Abs(Mathf.DeltaAngle(currentRotation.y, 90f)) < angleThreshold;
        bool isXAt0 = Mathf.Abs(Mathf.DeltaAngle(currentRotation.x, 0f)) < angleThreshold;
        bool isZAt0 = Mathf.Abs(Mathf.DeltaAngle(currentRotation.z, 0f)) < angleThreshold;

        if (isXAt0 && isYAt90 && isZAt0)
        {
            SceneManager.LoadScene(targetSceneName);
        }
    }
}

