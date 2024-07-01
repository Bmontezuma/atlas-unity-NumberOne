using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseCanvas;
    private bool isPaused = false;

    void Start()
    {
        // Ensure PauseCanvas starts inactive
        pauseCanvas.SetActive(false);
    }

    void Update()
    {
        // Check for pause/unpause input
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        // Pause the game
        Time.timeScale = 0f;
        isPaused = true;

        // Activate the PauseCanvas
        pauseCanvas.SetActive(true);
    }

    public void Resume()
    {
        // Unpause the game
        Time.timeScale = 1f;
        isPaused = false;

        // Deactivate the PauseCanvas
        pauseCanvas.SetActive(false);
    }

    public void Restart()
    {
        // Restart the current level
        Time.timeScale = 1f;  // Ensure time is running normally
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        // Load the MainMenu scene
        Time.timeScale = 1f;  // Ensure time is running normally
        SceneManager.LoadScene("MainMenu");
    }

    public void Options()
    {
        // Load the Options scene
        Time.timeScale = 1f;  // Ensure time is running normally
        SceneManager.LoadScene("Options");
    }
}
