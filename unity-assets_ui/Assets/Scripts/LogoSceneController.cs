using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoSceneController : MonoBehaviour
{
    public float displayTime = 5f; // Time to display the logo

    void Start()
    {
        Invoke("LoadNextScene", displayTime);
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene("NextSceneName"); // Replace with your next scene name
    }
}
