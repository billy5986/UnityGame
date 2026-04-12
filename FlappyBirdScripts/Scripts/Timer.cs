using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public int timer = 3;
    public Bird bird;
    public Launcher launcher;
    public CameraMove cameramove;

    protected void Start()
    {
        
        InvokeRepeating("SetTimer",1,1);
    }

    void SetTimer()
    {
        timer = timer - 1;
        timerText.text=timer.ToString();
        if(timer == 0)
        {
            CancelInvoke("SetTimer");
            timerText.text = string.Empty;
            bird.StartPlay();
            bird.PlayBGM();
            launcher.StartPlay();
            cameramove.StartPlay();
        }
    }

}
