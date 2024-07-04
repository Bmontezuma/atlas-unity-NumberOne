using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI TimerText;
    public float time = 0f;
    private bool timerRunning = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timerRunning)
        {
            time += Time.deltaTime;
            TimerText.text = time.ToString("0:00.00");
        }
    }

    public void StartTimer()
    {
        timerRunning = true;
    }

    public void StopTimer()
    {
        timerRunning = false;
    }

    public void Win(TextMeshProUGUI finalTimeText)
    {
        StopTimer();
        finalTimeText.text = TimerText.text;
    }
}
