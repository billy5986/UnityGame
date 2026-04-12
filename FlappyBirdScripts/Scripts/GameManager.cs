using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public int score = 0;

    public Text hiscoreText;
    public int hiscore;

    public static GameManager instance;

    public Launcher launcher;
    public int increasingDifficulty = 5;

    public Text nextLevelText;
    public int nextLevel;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        // 讀取上次儲存的最高分
        hiscore = PlayerPrefs.GetInt("HighScore");
        hiscoreText.text = "HiScore:" + hiscore.ToString();

        scoreText.text = "Score:" + score.ToString();
    }

    public void QuitGame()
    {
        SaveHighScore();
        Application.Quit();
    }

    public void AddScore()
    {
        score++;
        scoreText.text = "Score:" + score.ToString();
        Debug.Log("Score: " + score);

        if (score == nextLevel)
        {
            nextLevel = nextLevel + 5;
        }

        nextLevelText.text = "NextLevel:" + score + "/" + nextLevel.ToString();

        if (score % increasingDifficulty == 0)
        {
            if (launcher != null)
            {
                float newRate = launcher.rateTime - 0.2f;

                if (newRate < 0.1f)
                    newRate = 0.1f;

                launcher.UpdateSpawnRate(newRate);
                Debug.Log("New Rate: " + launcher.rateTime);
            }
            else
            {
                Debug.LogWarning("Launcher is null! Assign it in Inspector!");
            }
        }

        // 若目前分數 > 最高分，更新並存檔
        if (score > hiscore)
        {
            hiscore = score;
            hiscoreText.text = "HiScore:" + hiscore.ToString();
            PlayerPrefs.SetInt("HighScore", hiscore);
            PlayerPrefs.Save();
        }
    }

    void SaveHighScore()
    {
        PlayerPrefs.SetInt("HighScore", hiscore);
        PlayerPrefs.Save();
    }
}
