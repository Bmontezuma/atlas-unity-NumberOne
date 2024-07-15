using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ColorfulTitleTMP : MonoBehaviour
{
    public TextMeshProUGUI textBox;
    private List<Color> colors = new List<Color>
    {
        Color.red,                    // Red
        new Color(1.0f, 0.5f, 0.0f),  // Orange
        Color.yellow,                 // Yellow
        Color.green,                  // Green
        Color.blue,                   // Blue
        new Color(0.5f, 0.0f, 1.0f),  // Purple
        new Color(1.0f, 0.75f, 0.8f), // Pink
        Color.cyan,                   // Cyan
        Color.magenta,                // Magenta
        new Color(0.75f, 1.0f, 0.0f)  // Lime
    };

    void Start()
    {
        if (textBox == null)
        {
            Debug.LogError("TextBox not set.");
            return;
        }

        UpdateTextColors();
    }

    void UpdateTextColors()
    {
        string originalText = textBox.text;
        string coloredText = "";

        // Apply colors to each letter
        for (int i = 0; i < originalText.Length; i++)
        {
            Color color = colors[i % colors.Count];
            string colorHex = ColorUtility.ToHtmlStringRGBA(color);
            coloredText += $"<color=#{colorHex}>{originalText[i]}</color>";
        }

        // Set the colored text
        textBox.text = coloredText;
    }
}
