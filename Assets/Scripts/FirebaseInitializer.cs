using Firebase;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirebaseInitializer : MonoBehaviour
{
    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                Debug.Log("Firebase is ready");
                // Proceed with other initializations or directly load the game scene
            }
            else
            {
                Debug.LogError($"Could not resolve all Firebase dependencies: {dependencyStatus}");
                // Handle the error appropriately
            }
        });
    }
}
