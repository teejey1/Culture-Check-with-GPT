using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TriviaQuestion
{
    public string questionText;
    public List<string> options;
    public int correctAnswerIndex;
    public string category;
    public string mediaPath;

    // Default parameterless constructor for Firestore deserialization
    public TriviaQuestion() { }

    // Custom constructor for other uses
    public TriviaQuestion(string questionText, List<string> options, int correctAnswerIndex, string category, string mediaPath)
    {
        this.questionText = questionText;
        this.options = options;
        this.correctAnswerIndex = correctAnswerIndex;
        this.category = category;
        this.mediaPath = mediaPath;
    }
}
