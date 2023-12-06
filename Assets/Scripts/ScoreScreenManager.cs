// ScoreScreenManager.cs
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreScreenManager : MonoBehaviour
{
    public TMP_Text scoreText; // Assign in Inspector

    void Start()
    {
        // Display the score
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);
        scoreText.text = "Your Score: " + finalScore;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("CategoryScene"); // Replace with your main category scene name
    }
}
