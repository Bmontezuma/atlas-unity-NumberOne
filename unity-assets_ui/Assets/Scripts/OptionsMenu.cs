using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public Toggle invertYToggle;

    private void Start()
    {
        // Load the invert Y-axis setting and update the toggle
        invertYToggle.isOn = PlayerPrefs.GetInt("InvertY", 0) == 1;
    }

    public void Apply()
    {
        // Save the invert Y-axis setting
        PlayerPrefs.SetInt("InvertY", invertYToggle.isOn ? 1 : 0);

        // Return to the previous scene
        SceneManager.LoadScene(PlayerPrefs.GetString("PreviousScene", "MainMenu"));
    }

    public void Back()
    {
        // Discard changes and return to the previous scene
        SceneManager.LoadScene(PlayerPrefs.GetString("PreviousScene", "MainMenu"));
    }
}
