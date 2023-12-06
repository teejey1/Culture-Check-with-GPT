using Firebase.Firestore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class FirestoreDataFetcher
{
    // Firebase Firestore database reference
    private FirebaseFirestore db;

    // Constructor to initialize the Firestore instance
    public FirestoreDataFetcher()
    {
        // Assigning the default Firestore instance to 'db'
        db = FirebaseFirestore.DefaultInstance;
    }

    // Method to fetch questions from Firestore
    public void FetchQuestions(System.Action<List<TriviaQuestion>> onQuestionsFetched)
    {
        // Asynchronously getting a snapshot of the 'triviaQuestions' collection
        db.Collection("triviaQuestions").GetSnapshotAsync().ContinueWith(task =>
        {
            // Checking if the task encountered any errors (faults) or was canceled
            if (task.IsFaulted || task.IsCanceled)
            {
                // Logging an error message with the encountered exception
                Debug.LogError("Error fetching questions: " + task.Exception);
                // Invoking the callback with 'null' to signify an error occurred
                onQuestionsFetched?.Invoke(null);
                return;
            }

            // If the task is successful, getting the result of the query snapshot
            QuerySnapshot snapshot = task.Result;
            // Creating a list to store the converted TriviaQuestion objects
            List<TriviaQuestion> fetchedQuestions = new List<TriviaQuestion>();
            // Iterating through each document in the snapshot
            foreach (DocumentSnapshot document in snapshot.Documents)
            {
                // Converting the document to a TriviaQuestion object
                TriviaQuestion question = document.ConvertTo<TriviaQuestion>();
                // Adding the converted question to the list
                fetchedQuestions.Add(question);
            }

            // Invoking the callback with the list of fetched questions
            onQuestionsFetched?.Invoke(fetchedQuestions);
        }, TaskScheduler.FromCurrentSynchronizationContext()); // Ensuring the continuation runs on the main Unity thread
    }
}
