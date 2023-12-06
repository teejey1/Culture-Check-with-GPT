using Firebase.Firestore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class FirestoreQueries : MonoBehaviour
{
    FirebaseFirestore db;

    void Start()
    {
        db = FirebaseFirestore.DefaultInstance;
    }

    public async Task FetchQuestionsByCategory(string category, string subCategory)
    {
        var query = db.Collection("triviaQuestions")
                      .WhereEqualTo("category", category)
                      .WhereEqualTo("subCategory", subCategory);

        try
        {
            QuerySnapshot snapshot = await query.GetSnapshotAsync();
            List<TriviaQuestion> questions = new List<TriviaQuestion>();
            foreach (DocumentSnapshot document in snapshot.Documents)
            {
                TriviaQuestion question = document.ConvertTo<TriviaQuestion>();
                questions.Add(question);
            }

            // Pass questions to TriviaGameManager
            TriviaGameManager.Instance.SetQuestions(questions);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error fetching questions: " + e.Message);
        }
    }
}
