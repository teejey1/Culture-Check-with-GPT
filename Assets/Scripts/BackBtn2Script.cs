using UnityEngine;
using UnityEngine.SceneManagement;

public class BackBtn2Script : MonoBehaviour
{
    public void OnBackButtonClick()
    {
        SceneManager.LoadScene("CategoryScene"); // Load the Category Scene
    }
}
