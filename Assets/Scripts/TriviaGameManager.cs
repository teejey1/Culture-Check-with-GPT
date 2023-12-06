using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public enum GameState
{
    NotStarted,
    InProgress,
    Finished
}

public class TriviaGameManager : MonoBehaviour
{
    public static TriviaGameManager Instance { get; private set; }
    public GameState CurrentState { get; private set; }
    public int Score { get; private set; }
    private List<TriviaQuestion> questions;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            CurrentState = GameState.NotStarted;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartGameWithCategory(string category, string subCategory)
    {
        CurrentState = GameState.InProgress;
        Score = 0;
        FirestoreQueries firestoreQueries = GetComponent<FirestoreQueries>();
        firestoreQueries.FetchQuestionsByCategory(category, subCategory);
    }

    public void SetQuestions(List<TriviaQuestion> fetchedQuestions)
    {
        questions = fetchedQuestions;
        // Start the actual game with these questions
        SceneManager.LoadScene("TriviaScene");
    }

    public void EndGame()
    {
        CurrentState = GameState.Finished;
        // Logic for ending the game
        SceneManager.LoadScene("EndScene");
    }

    public void UpdateScore(int points)
    {
        Score += points;
        // Update the score display
    }

    // Additional methods for game logic
}
