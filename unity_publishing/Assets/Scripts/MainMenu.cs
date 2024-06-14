using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Material trapMat;
    public Material goalMat;
    public Material colorblindTrapMat;
    public Material colorblindGoalMat;
    public Toggle colorblindMode;

    private Material originalTrapMat;
    private Material originalGoalMat;

    void Start()
    {
        // Store original materials
        originalTrapMat = new Material(trapMat);
        originalGoalMat = new Material(goalMat);
    }

    public void PlayMaze()
    {
        // Toggle colorblind mode based on checkbox state
        bool colorblindActive = colorblindMode.isOn;

        if (colorblindActive)
        {
            // Apply colorblind mode materials
            trapMat.CopyPropertiesFromMaterial(colorblindTrapMat);
            goalMat.CopyPropertiesFromMaterial(colorblindGoalMat);
        }
        else
        {
            // Revert to original materials
            trapMat.CopyPropertiesFromMaterial(originalTrapMat);
            goalMat.CopyPropertiesFromMaterial(originalGoalMat);
        }

        SceneManager.LoadScene("maze"); // Ensure "maze" matches the exact name of your maze scene
    }

    public void QuitMaze()
    {
        Debug.Log("Quit Game");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
