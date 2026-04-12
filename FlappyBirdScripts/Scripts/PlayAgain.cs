using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playagain : MonoBehaviour
{
    public void PlayAgain()
    {
        Time.timeScale = 1f; // «ì´_®É¶¡
        SceneManager.LoadScene("FlappyBird");
    }

}
