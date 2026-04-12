using UnityEngine;

public class Launcher : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float rateTime = 2;

    public void StartPlay()
    {
        InvokeRepeating("CreateObstacle", 0, rateTime);
    }

    void CreateObstacle()
    {
        Instantiate(obstaclePrefab, transform.position, transform.rotation);
    }

    public void UpdateSpawnRate(float newRate)
    {
        rateTime = newRate;

        CancelInvoke("CreateObstacle");
        InvokeRepeating("CreateObstacle", rateTime, rateTime);
    }
}
