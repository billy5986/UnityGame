using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public Light flickerLight;           // 需要控制的光源
    public float minIntensity = 0.5f;    // 最低亮度
    public float maxIntensity = 2.0f;    // 最高亮度
    public float flickerSpeed = 5.0f;    // 控制亮度變化的速度
    public float flickerInterval = 0.5f; // 閃爍間隔時間（秒）

    private float targetIntensity;       // 當前目標亮度
    private float timer;                 // 計時器

    void Start()
    {
        if (flickerLight == null)
        {
            flickerLight = GetComponent<Light>();
        }
        targetIntensity = flickerLight.intensity;
    }

    void Update()
    {
        timer += Time.deltaTime;

        // 當計時器超過閃爍間隔時才更新亮度
        if (timer >= flickerInterval)
        {
            timer = 0f; // 重置計時器
            targetIntensity = Random.Range(minIntensity, maxIntensity);
        }

        // 使用Lerp平滑過渡到目標亮度
        flickerLight.intensity = Mathf.Lerp(flickerLight.intensity, targetIntensity, flickerSpeed * Time.deltaTime);
    }
}

