using System.Collections.Generic;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    public static QuestionManager Instance;

    private Queue<TriviaQuestion> questionsQueue = new Queue<TriviaQuestion>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadQuestions(List<TriviaQuestion> questions)
    {
        foreach (var question in questions)
        {
            questionsQueue.Enqueue(question);
        }
    }

    public TriviaQuestion GetNextQuestion()
    {
        if (questionsQueue.Count > 0)
        {
            return questionsQueue.Dequeue();
        }
        else
        {
            Debug.LogWarning("Out of questions!");
            return null;
        }
    }
}
