using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class SettingsButtonScript : MonoBehaviour
{
    public void OnSettingsButtonClick()
    {
        // Load the SettingsScene
        SceneManager.LoadScene("SettingsScene"); // Make sure the scene name matches exactly
    }
}
