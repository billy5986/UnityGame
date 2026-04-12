using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    public float speed = 2f;
    public Rigidbody2D rb2d;
    public float force = 10f;
    public float minVelY;
    public float maxVelY;
    public bool isPlaying = false;
    public bool isPaused = false;
    public GameManager gameManager;
    public Image[] hearts;
    public int lifes = 3;
    public GameObject gameOverCanva;
    public AudioSource audioSource;
    public AudioClip hitSource;
    public AudioClip pointSource;
    public AudioSource bgmSource;
    public AudioClip backgroundMusic;
    public Text nextLevelText;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(1, 0) * speed;
        gameOverCanva.SetActive(false);
    }

    public void PlayBGM()
    {
        bgmSource.clip = backgroundMusic;
        bgmSource.loop = true; 
        bgmSource.Play();
    }

// Update is called once per frame
void Update()
    {
        if (isPlaying == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("空白鍵");
                rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                rb2d.AddForce(Vector2.up * force, ForceMode2D.Impulse);
            }
        }

    }

    private void FixedUpdate()
    {
        float lerpT = rb2d.velocity.y + (maxVelY - minVelY) * 0.75f / (maxVelY - minVelY);
        float angle = Mathf.Lerp(-90,30,Mathf.Clamp01(lerpT));
        rb2d.MoveRotation(angle);
    }

    public void StartPlay()
    {
        isPlaying = true;
        //下面也等於GetComponent<Rigidbody2D>().gravityScale = 1;
        rb2d.gravityScale = 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            audioSource.PlayOneShot(hitSource);
            LoseLife();
        }
        if (collision.gameObject.tag == "Coin")
        {
            audioSource.PlayOneShot(pointSource);
            gameManager.AddScore();
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            audioSource.PlayOneShot(hitSource);
            LoseLife();
        }
    }

    void LoseLife()
    {
        lifes--;
        if (lifes >= 0 && lifes < hearts.Length)
        {
            hearts[lifes].gameObject.SetActive(false);
        }
        if (lifes == 0) 
        {
            gameOverCanva.SetActive(true);
            Time.timeScale = 0f; // 暫停遊戲
            Debug.Log("Game Over! 停止背景音樂");
            bgmSource.Stop();
            nextLevelText.gameObject.SetActive(false);

        }
    }

}
