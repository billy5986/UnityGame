using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class GhostAI : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent agent;
    private Light playerFlashlight;

    public float minSpeed = 2f;
    public float maxSpeed = 6f;
    public float speedIncreaseDistance = 10f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updatePosition = true;
        agent.speed = minSpeed;
    }

    void Update()
    {
        if (player != null && agent != null)
        {
            float distance = Vector3.Distance(transform.position, player.position);

            agent.speed = Mathf.Lerp(minSpeed, maxSpeed, 1 - (distance / speedIncreaseDistance));
            agent.speed = Mathf.Clamp(agent.speed, minSpeed, maxSpeed);

            agent.SetDestination(player.position);

            Vector3 direction = player.position - transform.position;
            direction.y = 0;

            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = targetRotation;
                transform.rotation *= Quaternion.Euler(0, 0, 0);
            }

            if (playerFlashlight != null && playerFlashlight.enabled)
                agent.isStopped = false;
            else
                agent.isStopped = true;
        }
    }

    public void SetPlayer(Transform playerTransform, Light flashlight)
    {
        player = playerTransform;
        playerFlashlight = flashlight;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("碰到: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("抓到玩家");
            GameManager.Instance.GameOver();
        }
    }

}