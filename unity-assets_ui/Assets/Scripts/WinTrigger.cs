using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinTrigger : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public int increasedFontSize = 60;
    public Color winColor = Color.green;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Timer playerTimer = other.GetComponent<Timer>();
            if (playerTimer != null)
            {
                playerTimer.StopTimer();
                timerText.fontSize = increasedFontSize;
                timerText.color = winColor;
            }
        }
    }
}