using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButtonScript : MonoBehaviour
{
    public void OnBackButtonClick()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
