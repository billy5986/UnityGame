using UnityEngine;

public class DisappearOnChildTrigger : MonoBehaviour
{
    public Light targetLight;
    public GameObject invisibleWall;
    private void OnTriggerEnter(Collider other)
    {
        invisibleWall.SetActive(false);

        if (other.CompareTag("Player"))
        {
            invisibleWall.SetActive(true);
            Destroy(gameObject);
            Destroy(targetLight.gameObject);
        }
    }
}

