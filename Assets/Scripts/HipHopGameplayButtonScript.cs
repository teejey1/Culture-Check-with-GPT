using UnityEngine;
using UnityEngine.SceneManagement;

public class HipHopGameplayButtonScript : MonoBehaviour
{
    public void LoadGameplayScene()
    {
        SceneManager.LoadScene("TriviaScene"); // Load the Trivia Scene
    }
}
